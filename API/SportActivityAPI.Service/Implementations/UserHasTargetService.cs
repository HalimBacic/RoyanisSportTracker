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
    public class UserHasTargetService : IUserHasTargetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserHasTargetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserHasTargetResponse> CreateUserTarget(UserHasTargetRequest userHasTargetRequest)
        {
            UserHasTarget userHasTarget = _mapper.Map<UserHasTarget>(userHasTargetRequest);
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

        public async Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargets(int userId)
        {
            if (userId == 0)
                throw new InvalidQueryParametresException(ExceptionsMessages.InvalidParametres);

            IEnumerable<UserHasTarget> targets = await _unitOfWork.UserHasTargetRepository.FindBy(x => x.UserId == userId).ToListAsync();
            return _mapper.Map<IEnumerable<UserHasTargetResponse>>(targets);
        }

        public async Task<IEnumerable<UserHasTargetResponse>> GetAllUserTargetsFiltered(int userId, bool finished)
        {
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
