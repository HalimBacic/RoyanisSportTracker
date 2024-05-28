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

        public async Task<ActivityResponse> CreateActivityForUser(ActivityRequest request, string username)
        {
            User user = await _unitOfWork.UserRepository.FindBy(x => x.Username == username).FirstAsync();
            if (user != null)
            {
                Activity activity = _mapper.Map<Activity>(request);
                user.Activity.Add(activity);
                await _unitOfWork.Complete();
                return _mapper.Map<ActivityResponse>(activity);
            }
            else
                throw new IncopatibleDatabaseException(ExceptionsMessages.NotFoundIndatabase);
        }

        public async Task DeleteActivityForUser(string username, int activityId)
        {
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

        public async Task<IEnumerable<ActivityResponse>> GetActivitiesForUser(string username)
        {
            User user = await FindUserInDatabaseAsync(username);

            return _mapper.Map<IEnumerable<ActivityResponse>>(user.Activity);
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
