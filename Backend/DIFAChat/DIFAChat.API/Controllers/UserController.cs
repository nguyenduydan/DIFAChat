using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIFAChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController() 
        { 
        }

        [HttpGet]
        public async Task<IActionResult> ShowList()
        {

            return Ok("Successed");
        }
    }
}
