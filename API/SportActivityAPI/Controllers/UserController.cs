using Microsoft.AspNetCore.Mvc;
using SportActivityAPI.Service.Interfaces;
using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IAuthService _authService;


        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserResponse>> RegisterUser([FromBody] UserRequest request)
        {
            return Ok(await _userService.RegisterUser(request));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserResponse>> LoginUser([FromBody] UserRequest request)
        {
            UserResponse loged = await _userService.LoginUser(request);
            if (loged != null)
            {
                var token = _authService.GenerateToken(loged.Email, loged.Username);
                var refreshToken = _authService.GenerateRefreshToken();

                return Ok(new { Token = token, RefreshToken = refreshToken });
            }

            return Unauthorized();
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] RefreshUserTokenRequest refreshModel)
        {
            var newToken = _authService.GenerateToken(refreshModel.Email, refreshModel.Username);
            var newRefreshToken = _authService.GenerateRefreshToken();

            return Ok(new { Token = newToken, RefreshToken = newRefreshToken });
        }
    }
}
