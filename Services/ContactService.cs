using Abner_WebAPI_Backend.Controllers;
using Abner_WebAPI_Backend.Interfaces;
using Abner_WebAPI_Backend.Model;
using Abner_WebAPI_Backend.Persistence;

namespace Abner_WebAPI_Backend.Services
{
    public class ContactService: IContactService
    {
        public List<ContactModel> GetContacts(int userId)
        {  
            var user = UserService.UserList.FirstOrDefault(u => u.userid == userId);
            if (user == null)
                throw new Exception("User not found");

            return user.Contacts;
        }

        public ContactModel AddContact(int userId, ContactModel contact)
        {
            var user = UserService.UserList.FirstOrDefault(u => u.userid == userId);
            if (user == null)
                throw new Exception("User not found");

            contact.contactid = user.Contacts.Any() ? user.Contacts.Max(c => c.contactid) + 1 : 1;
            user.Contacts.Add(contact);
            ContactPersistence.SaveJson(userId);
            return contact;
        }

        public ContactModel UpdateContact(int userId, int contactId, ContactModel updatedContact)
        {
            var user = UserService.UserList.FirstOrDefault(u => u.userid == userId);
            if (user == null)
                throw new Exception("User not found");

            var contact = user.Contacts.FirstOrDefault(c => c.contactid == contactId);
            if (contact == null)
                throw new Exception("Contact not found");

            contact.name = updatedContact.name;
            contact.phone = updatedContact.phone;
            contact.email = updatedContact.email;
            contact.address = updatedContact.address;

            UserPersistence.SaveJson();
            return contact;
        }

        public bool DeleteContact(int userId, int contactId)
        {
            var user = UserService.UserList.FirstOrDefault(u => u.userid == userId);
            if (user == null)
                throw new Exception("User not found");

            var contact = user.Contacts.FirstOrDefault(c => c.contactid == contactId);
            if (contact == null)
                throw new Exception("Contact not found");

            user.Contacts.Remove(contact);
            UserPersistence.SaveJson();
            return true;
        }
    }
}
