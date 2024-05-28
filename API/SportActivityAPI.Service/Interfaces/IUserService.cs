using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Service.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponse> RegisterUser(UserRequest request);
        public Task<UserResponse> LoginUser(UserRequest userRequest);
    }
}
