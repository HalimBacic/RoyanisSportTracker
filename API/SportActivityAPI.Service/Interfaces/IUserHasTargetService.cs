using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Service.Interfaces
{
    public interface IUserHasTargetService
    {
        public Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargets(string username, int currentpage, int pages);
        public Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargetsFiltered(string username, bool finished);
        public Task<UserHasTargetResponse> CreateUserTarget(UserHasTargetRequest userHasTarget, string? username);
        public Task DeleteUserTarget(DeleteUserTargetRequest deleteUserTargetRequest);
    }
}
