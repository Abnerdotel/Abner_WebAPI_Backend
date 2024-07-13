using Abner_WebAPI_Backend.Model;
using Abner_WebAPI_Backend.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abner_WebAPI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet("user/{userId}")]
        public IActionResult GetContacts(int userId)
        {
            var user = UserController.UserList.FirstOrDefault(u => u.userid == userId);
            if (user == null)
                return NotFound("User not found");

            return Ok(user.Contacts);
        }

        [HttpPost("user/{userId}")]
        public IActionResult AddContact(int userId, [FromBody] ContactModel contact)
        {
            var user = UserController.UserList.FirstOrDefault(u => u.userid == userId);
            if (user == null)
                return NotFound("User not found");

            contact.contactid = user.Contacts.Any() ? user.Contacts.Max(c => c.contactid) + 1 : 1;
            user.Contacts.Add(contact);
            ContactPersistence.SaveJson(userId);
            return Ok(contact);
        }

        [HttpPut("user/{userId}/contact/{contactId}")]
        public IActionResult UpdateContact(int userId, int contactId, [FromBody] ContactModel updatedContact)
        {
            var user = UserController.UserList.FirstOrDefault(u => u.userid == userId);
            if (user == null)
                return NotFound("User not found");

            var contact = user.Contacts.FirstOrDefault(c => c.contactid == contactId);
            if (contact == null)
                return NotFound("Contact not found");

            contact.name = updatedContact.name;
            contact.phone = updatedContact.phone;
            contact.email = updatedContact.email;
            contact.address = updatedContact.address;

            UserPersistence.SaveJson();
            return Ok(contact);
        }

        [HttpDelete("user/{userId}/contact/{contactId}")]
        public IActionResult DeleteContact(int userId, int contactId)
        {
            var user = UserController.UserList.FirstOrDefault(u => u.userid == userId);
            if (user == null)
                return NotFound("User not found");

            var contact = user.Contacts.FirstOrDefault(c => c.contactid == contactId);
            if (contact == null)
                return NotFound("Contact not found");

            user.Contacts.Remove(contact);
            UserPersistence.SaveJson();
            return Ok("Contact deleted");


        }
    }
}

