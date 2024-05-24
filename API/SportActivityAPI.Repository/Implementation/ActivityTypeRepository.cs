using SportActivityAPI.Repository.Interfaces;
using SportActivityAPI.Repository.Models;

namespace SportActivityAPI.Repository.Implementation
{
    internal class ActivityTypeRepository : GenericRepository<Activitytype>, IActivityTypeRepository
    {
        public ActivityTypeRepository(SporttrackerContext context) : base(context)
        {
        }
    }
}
