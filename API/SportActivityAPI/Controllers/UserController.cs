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

        /// <summary>
        /// Controller for register user. 
        /// User register yourself with username, email and password. All is unique in database
        /// </summary>
        /// <param name="request">Contains informations about user registration. 
        /// Id is parameter for database input and its automaticaly generated. 
        /// Not required in UserReguest
        /// </param>
        /// <returns>
        /// If successfull, service return email and username for registered user.
        /// </returns>
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserResponse>> RegisterUser([FromBody] UserRequest request)
        {
            return Ok(await _userService.RegisterUser(request));
        }


        /// <summary>
        /// Method for login user.
        /// </summary>
        /// <param name="request">
        ///  UserRequest must contain username and password.
        /// </param>
        /// <returns>
        /// If password and username is ok, return token for authentification on servises
        /// </returns>
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

        /// <summary>
        /// Refresh token for user. Currently not in use
        /// </summary>
        /// <param name="refreshModel"></param>
        /// <returns></returns>
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] RefreshUserTokenRequest refreshModel)
        {
            var newToken = _authService.GenerateToken(refreshModel.Email, refreshModel.Username);
            var newRefreshToken = _authService.GenerateRefreshToken();

            return Ok(new { Token = newToken, RefreshToken = newRefreshToken });
        }
    }
}
