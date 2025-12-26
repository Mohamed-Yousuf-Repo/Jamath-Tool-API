using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Administration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JamathController : ControllerBase
    {
        public JamathController()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([Required] DateTime StartDate, DateTime? EndDate)
        {
            //var 
            return Ok();
        }
    }
}
