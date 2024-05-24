using SportActivityAPI.Repository.Interfaces;
using SportActivityAPI.Repository.Models;

namespace SportActivityAPI.Repository.Implementation
{
    internal class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(SporttrackerContext context) : base(context)
        {
        }
    }
}
