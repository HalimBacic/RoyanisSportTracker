using AutoMapper;
using SportActivityAPI.Repository.Implementation;
using SportActivityAPI.Repository.Interfaces;
using SportActivityAPI.Repository.Models;

namespace SportActivityAPI.Repository.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SporttrackerContext _context;
        private readonly IMapper _mapper;

        private IActivityTypeRepository? ActivityTypeRepo { get; set; }
        private IActivityRepository? ActivityRepo { get; set; }
        private IUserHasTargetRepository? UserHasTargetRepo { get; set; }
        private IUserRepository? UserRepo { get; set; }

        public IActivityRepository ActivityRepository
        {
            get
            {
                if (ActivityRepo == null)
                    return new ActivityRepository(_context);

                return ActivityRepo;
            }
        }

        public IUserHasTargetRepository UserHasTargetRepository => throw new NotImplementedException();

        public IActivityTypeRepository ActivityTypeRepository => throw new NotImplementedException();

        public IUserRepository UserRepository
        {
            get
            {
                if (UserRepo == null)
                    return new UserRepository(_context);

                return UserRepo;
            }
        }

        public UnitOfWork(SporttrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Complete() => await _context.SaveChangesAsync();

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
