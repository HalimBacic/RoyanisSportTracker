using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportActivityAPI.Repository.Models;
using SportActivityAPI.Repository.UnitsOfWork;
using SportActivityAPI.Service.Interfaces;
using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Service.Implementations
{
    public class UserHasTargetService : IUserHasTargetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserHasTargetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserHasTargetResponse> CreateUserTarget(UserHasTargetRequest userHasTargetRequest, string? username)
        {
            int userId = await _unitOfWork.UserRepository.FindBy(x => x.Username == username).Select(x => x.Id).FirstAsync();
            userHasTargetRequest.UserId = userId;
            UserHasTarget userHasTarget = _mapper.Map<UserHasTarget>(userHasTargetRequest);
            userHasTarget.Count = 0;
            await _unitOfWork.UserHasTargetRepository.AddAsync(userHasTarget);
            await _unitOfWork.Complete();
            return _mapper.Map<UserHasTargetResponse>(userHasTarget);
        }

        public async Task DeleteUserTarget(DeleteUserTargetRequest deleteUserTargetRequest)
        {
            UserHasTarget userHasTargetToDelete = await _unitOfWork.UserHasTargetRepository.FindBy(x => x.UserId == deleteUserTargetRequest.UserId &&
                x.ActivityTypeId == deleteUserTargetRequest.ActivityTypeId && x.DateActivity == deleteUserTargetRequest.DateActivity).FirstAsync();

            _unitOfWork.UserHasTargetRepository.Delete(userHasTargetToDelete);
            await _unitOfWork.Complete();
        }

        public async Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargets(string username, int currentpage, int pages)
        {
            int userId = await _unitOfWork.UserRepository.FindBy(x => x.Username == username).Select(x => x.Id).FirstAsync();
            IEnumerable<UserHasTarget> targets = await _unitOfWork.UserHasTargetRepository.FindBy(x => x.UserId == userId).Skip((currentpage - 1) * pages).Take(pages).ToListAsync();
            return _mapper.Map<IEnumerable<UserHasTargetResponse>>(targets);
        }

        public async Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargetsFiltered(string username, bool finished)
        {
            int userId = await _unitOfWork.UserRepository.FindBy(x => x.Username == username).Select(x => x.Id).FirstAsync();
            switch (finished)
            {
                case false:
                    IEnumerable<UserHasTarget> targetsUnfinished = await _unitOfWork.UserHasTargetRepository.FindBy(x => x.UserId == userId && x.Count != x.Target).ToListAsync();
                    return _mapper.Map<IEnumerable<UserHasTargetResponse>>(targetsUnfinished);
                case true:
                    IEnumerable<UserHasTarget> targetsFinished = await _unitOfWork.UserHasTargetRepository.FindBy(x => x.UserId == userId && x.Count == x.Target).ToListAsync();
                    return _mapper.Map<IEnumerable<UserHasTargetResponse>>(targetsFinished);
            }
        }
    }
}
