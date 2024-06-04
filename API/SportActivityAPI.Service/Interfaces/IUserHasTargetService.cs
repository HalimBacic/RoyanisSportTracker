using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Service.Interfaces
{
    public interface IUserHasTargetService
    {
        public Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargets(string username);
        public Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargetsFiltered(string username, bool finished);
        public Task<UserHasTargetResponse> CreateUserTarget(UserHasTargetRequest userHasTarget);
        public Task DeleteUserTarget(DeleteUserTargetRequest deleteUserTargetRequest);
    }
}
