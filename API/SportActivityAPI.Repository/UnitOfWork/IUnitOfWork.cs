using SportActivityAPI.Repository.Interfaces;

namespace SportActivityAPI.Repository.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityRepository ActivityRepository { get; }
        IUserHasTargetRepository UserHasTargetRepository { get; }
        IActivityTypeRepository ActivityTypeRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> Complete();
    }
}
