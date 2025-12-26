using Administration.Domain.IServices;
using Administration.Domain.Models.RequestModels;
using Administration.Domain.Models.ResponseModels;
using Administration.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Authenticates a user using username and password.
        /// </summary>
        /// <response code="200">Login successful</response>
        /// <response code="401">Invalid credentials</response>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _accountService.ValidateUser(request.Username, request.Password);

            if (user == null)
                return Unauthorized("Invalid username or password.");

            var token = _tokenService.GenerateToken(user);
            return Ok(new LoginResponseModel
            {
                Token = token,
                TokenType = "Bearer",
                ExpiresInSeconds = 3600
            });
        }

        /// <summary>
        /// Create Default Users: Admin and Developer
        /// </summary>
        /// <returns>
        /// HTTP 200 if successful
        /// </returns>
        [HttpPost("CreateDefaultUsers")]
        public async Task<IActionResult> CreateDefaultUser()
        {
            await _accountService.CreateDefaultUsers();
            return Ok();
        }
    }
}
