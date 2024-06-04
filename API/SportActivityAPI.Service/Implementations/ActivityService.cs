using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportActivityAPI.Repository.Models;
using SportActivityAPI.Repository.UnitsOfWork;
using SportActivityAPI.Service.Interfaces;
using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;
using SportActivityAPI.Share.Exceptions;

namespace SportActivityAPI.Service.Implementations
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ActivityResponse> CreateActivityForUser(ActivityRequest request, string? username)
        {
            User user = await _unitOfWork.UserRepository.FindBy(x => x.Username == username).FirstAsync();
            if (user != null)
            {
                Activity activity = _mapper.Map<Activity>(request);
                activity.UserId = user.Id;
                user.Activity.Add(activity);
                await _unitOfWork.Complete();
                return _mapper.Map<ActivityResponse>(activity);
            }
            else
                throw new IncopatibleDatabaseException(ExceptionsMessages.NotFoundIndatabase);
        }

        public async Task DeleteActivityForUser(string? username, int activityId)
        {
            if (username == null)
                throw new IncopatibleDatabaseException($"Invalid username: {username}");

            User user = await FindUserInDatabaseAsync(username);
            Activity activity = await _unitOfWork.ActivityRepository.FindBy(x => x.Id == activityId).FirstAsync();
            if (activity != null)
            {
                user.Activity.Remove(activity);
                await _unitOfWork.Complete();
            }
            else
                throw new IncopatibleDatabaseException(ExceptionsMessages.NotFoundIndatabase);
        }

        public async Task<IEnumerable<ActivityResponse>> FilterActivities(DateOnly? date, int ActivityType)
        {
            IEnumerable<Activity> activities = await _unitOfWork.ActivityRepository.FindBy(x => x.ActivityTypeId == ActivityType).ToListAsync();

            if (date is not null)
                activities.Where(x => x.DateActivity == date);

            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<IEnumerable<ActivityResponse>> FindActivities(string? name, string? description)
        {
            if (name == null && description == null)
                throw new InvalidQueryParametresException(ExceptionsMessages.BothParametresNull);

            IEnumerable<Activity> activities = _unitOfWork.ActivityRepository.GetAll();

            if (name is not null)
                activities.Where(x => x.Name.Contains(name));
            if (description is not null)
                activities.Where(x => x.Description.Contains(description));

            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<IEnumerable<ActivityResponse>> GetActivities()
        {
            IEnumerable<Activitytype> activities = _unitOfWork.ActivityTypeRepository.GetAll();

            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<IEnumerable<ActivityResponse>> GetActivitiesForUser(string username)
        {
            User user = await FindUserInDatabaseAsync(username);

            return _mapper.Map<IEnumerable<ActivityResponse>>(user.Activity);
        }

        public async Task<ActivityResponse> UpdateActivity(ActivityRequest request, string? username)
        {
            Activity? activityDb = await _unitOfWork.ActivityRepository.FindBy(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (activityDb != null)
            {
                throw new IncopatibleDatabaseException(ExceptionsMessages.NotFoundIndatabase);
            }
            _mapper.Map(_mapper.Map<Activity>(request), activityDb);
            await _unitOfWork.Complete();
            return _mapper.Map<ActivityResponse>(activityDb);
        }

        private async Task<User> FindUserInDatabaseAsync(string username)
        {
            User user = await _unitOfWork.UserRepository.FindBy(x => x.Username == username).Include(x => x.Activity).FirstAsync();

            if (user is null)
                throw new IncopatibleDatabaseException(ExceptionsMessages.NotFoundIndatabase);

            return user;
        }
    }
}
