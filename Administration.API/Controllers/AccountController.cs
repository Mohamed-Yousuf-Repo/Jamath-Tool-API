using Administration.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        
        [HttpPost("CreateDefaultUsers")]
        public async Task<IActionResult> CreateDefaultUser()
        {
            await _accountService.CreateDefaultUsers();
            return Ok();
        }
    }
}
