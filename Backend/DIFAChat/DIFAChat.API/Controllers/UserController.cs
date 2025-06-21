using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DIFAChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DifaChatDbContext _db;
        public UserController(DifaChatDbContext db ) 
        { 
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> ShowList()
        {
            var users = await _db.users.ToListAsync();
            return Ok(users);
        }
    }
}
