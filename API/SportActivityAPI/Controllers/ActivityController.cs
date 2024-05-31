using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportActivityAPI.Service.Interfaces;
using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        [Route("GetActivities")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesForUser([FromQuery] string username)
        {
            return Ok(await _activityService.GetActivitiesForUser(username));
        }

        [HttpPost]
        [Route("CreateActivity")]
        public async Task<ActionResult<ActivityResponse>> CreateActivityForUser([FromBody] ActivityRequest request, [FromQuery] string username)
        {
            return Ok(await _activityService.CreateActivityForUser(request, username));
        }

        [HttpDelete]
        [Route("DeleteActivity")]
        public async Task<ActionResult> DeleteActivityForUser([FromQuery] string username, [FromQuery] int activityId)
        {
            await _activityService.DeleteActivityForUser(username, activityId);
            return NoContent();
        }
    }
}
