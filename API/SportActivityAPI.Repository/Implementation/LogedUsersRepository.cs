using SportActivityAPI.Repository.Interfaces;
using SportActivityAPI.Repository.Models;

namespace SportActivityAPI.Repository.Implementation
{
    internal class LogedUsersRepository : GenericRepository<Logedusers>, ILogedUsersRepository
    {
        public LogedUsersRepository(SporttrackerContext context) : base(context)
        {
        }
    }
}
