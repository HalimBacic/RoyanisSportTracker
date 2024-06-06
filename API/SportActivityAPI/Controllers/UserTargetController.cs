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
    public class UserTargetController : ControllerBase
    {

        private IUserHasTargetService _userHasTargetService;

        public UserTargetController(IUserHasTargetService userHasTargetService)
        {
            _userHasTargetService = userHasTargetService;
        }

        /// <summary>
        /// Create new activity for user
        /// </summary>
        /// <param name="request">
        /// Request is a model to add new target in database
        /// </param>
        /// <returns>
        /// Informations about new target in database
        /// </returns>
        [HttpPost]
        [Route("AddTarget")]
        public async Task<ActionResult<UserHasTargetResponse>> AddTarget([FromBody] UserHasTargetRequest request)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _userHasTargetService.CreateUserTarget(request, username));
        }

        /// <summary>
        /// Endpoint to get targets for user
        /// </summary>
        /// <param name="currentPage">Current page for pagination</param>
        /// <param name="pages">All pages in pagination</param>
        /// <returns>
        /// List of all targets for user
        /// </returns>
        [HttpGet]
        [Route("GetTargets")]
        public async Task<ActionResult<IEnumerable<UserHasTargetResponse>>> GetAllTargets([FromQuery] int currentPage, [FromQuery] int pages)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _userHasTargetService.GetAllUserTargets(username, currentPage, pages));
        }

        /// <summary>
        /// Return finished targets
        /// </summary>
        /// <param name="finished">bool parameter. True for finished, false for unfinished</param>
        /// <returns>
        /// List of user targets which is finished or unfinished
        /// </returns>
        [HttpGet]
        [Route("GetTargetsFiltered")]
        public async Task<ActionResult<IEnumerable<UserHasTargetResponse>>> GetAllTargetsFiltered([FromQuery] bool finished)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _userHasTargetService.GetAllUserTargetsFiltered(username, finished));
        }

        /// <summary>
        /// Endpoint for delete targets. Not in use currenty
        /// </summary>
        /// <param name="request">All keys for delete user target from database</param>
        /// <returns>
        /// Status code if deleted target
        /// </returns>
        [HttpDelete]
        [Route("DeleteTarget")]
        public async Task<ActionResult> DeleteTarget([FromBody] DeleteUserTargetRequest request)
        {
            await _userHasTargetService.DeleteUserTarget(request);
            return NoContent();
        }
    }
}
