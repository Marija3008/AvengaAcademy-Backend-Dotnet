using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<string> users = new List<string> 
        {
            "Marko",
            "Darko",
            "Marta",
            "Gordan",
            "Eva"
        };

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if (id < 0 || id >= users.Count)
            {
                return NotFound();
            }

            return Ok(users[id]);
        }
    }
}
