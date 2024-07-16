using Abner_WebAPI_Backend.Interfaces;
using Abner_WebAPI_Backend.Model;
using Abner_WebAPI_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Abner_WebAPI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetContacts(int userId)
        {
            try
            {
                var contacts = _contactService.GetContacts(userId);
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("user/{userId}")]
        public IActionResult AddContact(int userId, [FromBody] ContactModel contact)
        {
            try
            {
                var addedContact = _contactService.AddContact(userId, contact);
                return Ok(addedContact);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("user/{userId}/contact/{contactId}")]
        public IActionResult UpdateContact(int userId, int contactId, [FromBody] ContactModel updatedContact)
        {
            try
            {
                var updated = _contactService.UpdateContact(userId, contactId, updatedContact);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("user/{userId}/contact/{contactId}")]
        public IActionResult DeleteContact(int userId, int contactId)
        {
            try
            {
                var result = _contactService.DeleteContact(userId, contactId);
                if (result)
                    return Ok("Contact deleted");
                return BadRequest("Failed to delete contact");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
