using Abner_WebAPI_Backend.Model;

namespace Abner_WebAPI_Backend.Interfaces
{
    public interface IContactService
    {
        public interface IContactService
        {
            List<ContactModel> GetContacts(int userId);
            ContactModel AddContact(int userId, ContactModel contact);
            ContactModel UpdateContact(int userId, int contactId, ContactModel updatedContact);
            bool DeleteContact(int userId, int contactId);
        }
    }
}
