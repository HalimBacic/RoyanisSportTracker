using AutoMapper;
using SportActivityAPI.Repository.Models;
using SportActivityAPI.Repository.UnitsOfWork;
using SportActivityAPI.Service.Interfaces;
using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public UserResponse LoginUser(UserRequest userRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> RegisterUser(UserRequest request)
        {
            User user = _mapper.Map<User>(request);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.Complete();
            return _mapper.Map<UserResponse>(user);
        }
    }
}
