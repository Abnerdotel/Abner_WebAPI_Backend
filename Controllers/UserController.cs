using Abner_WebAPI_Backend.Model;
using Abner_WebAPI_Backend.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Abner_WebAPI_Backend.Controllers
{
        public static List<UserModel> UserList = new();

        [HttpGet("Users")]
        public IActionResult GetUsers()
        {
            return Ok(UserList);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserModel user)
        {
            try
            {
                if (UserList.Any(u => u.email == user.email))
                    return Conflict();

                user.userid = UserList.Count > 0 ? UserList.Max(u => u.userid) + 1 : 1;
                UserList.Add(user);
                UserPersistence.SaveJson();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserValidationModel model)
        {
            var user = UserList.FirstOrDefault(u => u.email == model.email);
            if (user == null || user.password != model.password)
                return Unauthorized();

            return Ok(user);
        }
    
}
