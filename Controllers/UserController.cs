using Abner_WebAPI_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Abner_WebAPI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<UserModel> users = new();

        [HttpGet("Usuarios")]
        public IActionResult GetUsers()
        {

            return Ok(users);

        }

        [HttpPost("Registro")]
        public IActionResult SetUsers([FromBody] UserModel usuario)
        {

        }

        [HttpPost("Login")]

        public IActionResult Register([FromBody] UserValidationModel usuario)
        {
        }
    }
}
