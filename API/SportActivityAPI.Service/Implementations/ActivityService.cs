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
            Activity activity = await _unitOfWork.ActivityRepository.FindBy(x => x.Id == activityId).FirstAsync();
            if (activity != null)
            {
                _unitOfWork.ActivityRepository.Delete(activity);
                await _unitOfWork.Complete();
            }
            else
                throw new IncopatibleDatabaseException(ExceptionsMessages.NotFoundIndatabase);
        }

        private async Task<IEnumerable<ActivityResponse>> FilterActivities(string username, DateOnly? date, int? activityType)
        {
            var activities = _unitOfWork.ActivityRepository.FindBy(x => x.User.Username == username);

            //If user send date and activity in one search
            if (date is not null && activityType is not null)
            {
                activities = activities.Where(x => x.DateActivity == date && x.ActivityTypeId == activityType);
            }
            else
            {
                if (date is not null)
                    activities = activities.Where(x => x.DateActivity == date);

                if (activityType is not null)
                    activities = activities.Where(x => x.ActivityTypeId == activityType);
            }

            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<IEnumerable<ActivityResponse>> FindActivities(string? username, string? name, string? description)
        {
            var activities = _unitOfWork.ActivityRepository.FindBy(x => x.User.Username == username);

            //if user want search by name and description
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                activities = activities.Where(x => x.Name.Contains(name) && x.Description.Contains(description));
            }
            else
            {
                if (!string.IsNullOrEmpty(name))
                    activities = activities.Where(x => x.Name.Contains(name));

                if (!string.IsNullOrEmpty(description))
                    activities = activities.Where(x => x.Description.Contains(description));
            }

            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<IEnumerable<ActivityResponse>> GetActivities()
        {
            IEnumerable<Activitytype> activities = _unitOfWork.ActivityTypeRepository.GetAll();

            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<IEnumerable<ActivityResponse>> GetActivitiesForUser(string username, int currentpage, int pages)
        {
            int userId = await _unitOfWork.UserRepository.FindBy(x => x.Username == username).Select(x => x.Id).FirstAsync();
            IEnumerable<Activity> activities = await _unitOfWork.ActivityRepository.FindBy(x => x.UserId == userId).Skip((currentpage - 1) * pages).Take(pages).ToArrayAsync();
            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<ActivityResponse> UpdateActivity(ActivityRequest request)
        {
            Activity? activityDb = await _unitOfWork.ActivityRepository.FindBy(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (activityDb == null)
            {
                throw new IncopatibleDatabaseException(ExceptionsMessages.NotFoundIndatabase);
            }
            _mapper.Map(request, activityDb);
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

        public async Task<IEnumerable<ActivityResponse>> FindActivitiesByDate(string? username, DateOnly? date)
        {
            int userId = await _unitOfWork.UserRepository.FindBy(x => x.Username == username).Select(x => x.Id).FirstAsync();
            IEnumerable<Activity> activities = await _unitOfWork.ActivityRepository.FindBy(x => x.UserId == userId && x.DateActivity == date).ToArrayAsync();
            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }

        public async Task<IEnumerable<ActivityResponse>> FindActivitiesByType(string? username, int type)
        {
            int userId = await _unitOfWork.UserRepository.FindBy(x => x.Username == username).Select(x => x.Id).FirstAsync();
            IEnumerable<Activity> activities = await _unitOfWork.ActivityRepository.FindBy(x => x.UserId == userId && x.ActivityTypeId == type).ToArrayAsync();
            return _mapper.Map<IEnumerable<ActivityResponse>>(activities);
        }
    }
}
