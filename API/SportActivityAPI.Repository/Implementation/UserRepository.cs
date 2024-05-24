using SportActivityAPI.Repository.Interfaces;
using SportActivityAPI.Repository.Models;

namespace SportActivityAPI.Repository.Implementation
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SporttrackerContext context) : base(context)
        {
        }
    }
}
