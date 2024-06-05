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
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesForUser([FromQuery] int currentPage, [FromQuery] int pages)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.GetActivitiesForUser(username, currentPage, pages));
        }

        [HttpPost]
        [Route("GetActivitiesSearch")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesSearch([FromBody] SearchRequest request)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.FindActivities(username, request.Name, request.Description));
        }

        [HttpGet]
        [Route("SearchByDate")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesByDateOrType([FromQuery] DateOnly? date)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.FindActivitiesByDate(username, date));
        }

        [HttpGet]
        [Route("SearchByType")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesByDateOrType([FromQuery] int type)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.FindActivitiesByType(username, type));
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

        [HttpPut]
        [Route("UpdateActivity")]
        public async Task<ActionResult<ActivityResponse>> UpdateActivityForUser([FromBody] ActivityRequest request)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.UpdateActivity(request));
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
