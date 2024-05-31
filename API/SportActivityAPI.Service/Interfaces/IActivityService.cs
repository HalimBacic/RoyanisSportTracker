using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Service.Interfaces
{
    public interface IActivityService
    {
        public Task<IEnumerable<ActivityResponse>> GetActivitiesForUser(string username);
        public Task<IEnumerable<ActivityResponse>> FilterActivities(DateOnly? date, int ActivityType);
        public Task<IEnumerable<ActivityResponse>> FindActivities(string? name, string? description);
        public Task<ActivityResponse> CreateActivityForUser(ActivityRequest request, string username);
        public Task<ActivityResponse> UpdateActivity(ActivityRequest request, string username);
        public Task DeleteActivityForUser(string username, int activityId);
    }
}
