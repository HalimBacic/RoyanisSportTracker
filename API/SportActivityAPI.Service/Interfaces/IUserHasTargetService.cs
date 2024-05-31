using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Service.Interfaces
{
    public interface IUserHasTargetService
    {
        public Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargets(int userId);
        public Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargetsFiltered(int userId, bool finished);
        public Task<UserHasTargetResponse> CreateUserTarget(UserHasTargetRequest userHasTarget);
        public Task DeleteUserTarget(DeleteUserTargetRequest deleteUserTargetRequest);
    }
}
