using SportActivityAPI.Repository.Interfaces;
using SportActivityAPI.Repository.Models;

namespace SportActivityAPI.Repository.Implementation
{
    internal class UserHasTargetRepository : GenericRepository<UserHasTarget>, IUserHasTargetRepository
    {
        public UserHasTargetRepository(SporttrackerContext context) : base(context)
        {
        }
    }
}
