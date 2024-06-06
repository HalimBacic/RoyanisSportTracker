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


        /// <summary>
        /// Return all activities for user. Username can be find in token if authorized.
        /// </summary>
        /// <param name="currentPage">Current page for paging options</param>
        /// <param name="pages">All pages for data</param>
        /// <returns>List of activities from database</returns>
        [HttpGet]
        [Route("GetActivities")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesForUser([FromQuery] int currentPage, [FromQuery] int pages)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.GetActivitiesForUser(username, currentPage, pages));
        }

        /// <summary>
        /// Find activities by name and description. Can be used for one or both parametres.
        /// </summary>
        /// <param name="request">Request contains Name and Description for search</param>
        /// <returns>List of activities with conditions in request</returns>
        [HttpPost]
        [Route("GetActivitiesSearch")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesSearch([FromBody] SearchRequest request)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.FindActivities(username, request.Name, request.Description));
        }

        /// <summary>
        /// Returns activities with date in endpoint path
        /// </summary>
        /// <param name="date">Date for search</param>
        /// <returns>
        /// List of activities with date in request
        /// </returns>
        [HttpGet]
        [Route("SearchByDate")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesByDate([FromQuery] DateOnly? date)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.FindActivitiesByDate(username, date));
        }


        /// <summary>
        /// Returns activities by type in endpoint path
        /// </summary>
        /// <param name="type">Type for search</param>
        /// <returns>
        /// List of activities with type in request
        /// </returns>
        [HttpGet]
        [Route("SearchByType")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivitiesByType([FromQuery] int type)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.FindActivitiesByType(username, type));
        }


        /// <summary>
        /// Endpoint to get all activities in database. Currently not in use
        /// </summary>
        /// <returns>
        /// List of all activities in database. 
        /// </returns>
        [HttpGet]
        [Route("GetAllActivities")]
        public async Task<ActionResult<IEnumerable<ActivityResponse>>> GetActivities()
        {
            return Ok(await _activityService.GetActivities());
        }



        /// <summary>
        /// Create activity for user
        /// </summary>
        /// <param name="request">Request contains informations for new activity for user</param>
        /// <returns>
        /// Created activity
        /// </returns>
        [HttpPost]
        [Route("CreateActivity")]
        public async Task<ActionResult<ActivityResponse>> CreateActivityForUser([FromBody] ActivityRequest request)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.CreateActivityForUser(request, username));
        }

        /// <summary>
        /// Update activity for user
        /// </summary>
        /// <param name="request">Updated activity request.</param>
        /// <returns>
        /// Updated activity
        /// </returns>
        [HttpPut]
        [Route("UpdateActivity")]
        public async Task<ActionResult<ActivityResponse>> UpdateActivityForUser([FromBody] ActivityRequest request)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _activityService.UpdateActivity(request));
        }

        /// <summary>
        /// Endpoint for delete activity
        /// </summary>
        /// <param name="activityId">ActivityId is id for activity in database.</param>
        /// <returns>
        /// Status code if deteled. 
        /// </returns>
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
