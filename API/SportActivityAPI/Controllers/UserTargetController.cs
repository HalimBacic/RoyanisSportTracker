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

        [HttpPost]
        [Route("AddTarget")]
        public async Task<ActionResult<UserHasTargetResponse>> AddTarget([FromBody] UserHasTargetRequest request)
        {
            return Ok(await _userHasTargetService.CreateUserTarget(request));
        }

        [HttpGet]
        [Route("GetTargets")]
        public async Task<ActionResult<IEnumerable<UserHasTargetResponse>>> GetAllTargets()
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _userHasTargetService.GetAllUserTargets(username));
        }

        [HttpGet]
        [Route("GetTargetsFiltered")]
        public async Task<ActionResult<IEnumerable<UserHasTargetResponse>>> GetAllTargetsFiltered([FromQuery] bool finished)
        {
            string? username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _userHasTargetService.GetAllUserTargetsFiltered(username, finished));
        }

        [HttpDelete]
        [Route("DeleteTarget")]
        public async Task<ActionResult> DeleteTarget([FromBody] DeleteUserTargetRequest request)
        {
            await _userHasTargetService.DeleteUserTarget(request);
            return NoContent();
        }
    }
}
