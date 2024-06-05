using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Service.Interfaces
{
    public interface IActivityService
    {
        public Task<IEnumerable<ActivityResponse>> GetActivitiesForUser(string username, int currentPage, int pages);
        public Task<IEnumerable<ActivityResponse>> GetActivities();
        public Task<IEnumerable<ActivityResponse>> FindActivities(string? username, string? name, string? description);

        public Task<IEnumerable<ActivityResponse>> FindActivitiesByDate(string? username, DateOnly? date);
        public Task<IEnumerable<ActivityResponse>> FindActivitiesByType(string? username, int type);
        public Task<ActivityResponse> CreateActivityForUser(ActivityRequest request, string? username);
        public Task<ActivityResponse> UpdateActivity(ActivityRequest request);
        public Task DeleteActivityForUser(string? username, int activityId);
    }
}
