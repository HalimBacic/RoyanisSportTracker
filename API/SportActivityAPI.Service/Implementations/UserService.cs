using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportActivityAPI.Repository.Models;
using SportActivityAPI.Repository.UnitsOfWork;
using SportActivityAPI.Service.Extensions;
using SportActivityAPI.Service.Interfaces;
using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;
using SportActivityAPI.Share.Exceptions;

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

        public async Task<UserResponse> LoginUser(UserRequest userRequest)
        {
            string passwordCrypted = await _unitOfWork.UserRepository.FindBy(x => x.Username == userRequest.Username).Select(x => x.Password).FirstAsync();

            if (passwordCrypted.CheckPassword(userRequest.Password))
                throw new UnauthorizedException(ExceptionsMessages.UserNotAuthorized);
            else
                userRequest.Password = passwordCrypted;

            return _mapper.Map<UserResponse>(userRequest);
        }

        public async Task<UserResponse> RegisterUser(UserRequest request)
        {
            request.Password = request.Password.ComputePassword();
            User user = _mapper.Map<User>(request);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.Complete();
            return _mapper.Map<UserResponse>(user);
        }
    }
}
