using Abner_WebAPI_Backend.Model;
using Abner_WebAPI_Backend.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Abner_WebAPI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<UserModel> ListaUsuario = new();

        [HttpGet("Usuarios")]
        public IEnumerable<UserModel> GetUsers()
        {
            return ListaUsuario;
        }


        [HttpPost("Registro")]
        public IActionResult SetUsers([FromBody] UserModel usuario)
        {
            try
            {
                foreach (UserModel user in ListaUsuario)
                {
                    if (user.email == usuario.email)
                    {
                        return Conflict();

                    }
                }
                if (ListaUsuario.Count > 0)
                {

                    usuario.userid = ListaUsuario.Last<UserModel>().userid + 1;
                }
                else
                {
                    usuario.userid = 1;
                }

                ListaUsuario.Add(usuario);
                UserPersistence.SaveJson();
                return Ok(usuario);

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]

        public IActionResult Register([FromBody] UserValidationModel usuario)
        {
            foreach (var user in ListaUsuario)
            {
                if (user.email == usuario.email)
                {
                    if (user.password == usuario.password)
                    {
                        return Ok(user);

                    }
                    else return Unauthorized();
                }
            }

            return NotFound();
        }
    }
}
