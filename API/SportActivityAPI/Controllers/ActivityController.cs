using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportActivityAPI.Service.Interfaces;
using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;
using System.Security.Claims;

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
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesForUser()
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.GetActivitiesForUser(username));
        }

        [HttpGet]
        [Route("GetAllActivities")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivities()
        {
            return Ok(await _activityService.GetActivities());
        }


        [HttpPost]
        [Route("CreateActivity")]
        public async Task<ActionResult<ActivityResponse>> CreateActivityForUser([FromBody] ActivityRequest request)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.CreateActivityForUser(request, username));
        }

        [HttpDelete]
        [Route("DeleteActivity")]
        public async Task<ActionResult> DeleteActivityForUser([FromQuery] int activityId)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _activityService.DeleteActivityForUser(username, activityId);
            return NoContent();
        }
    }
}
