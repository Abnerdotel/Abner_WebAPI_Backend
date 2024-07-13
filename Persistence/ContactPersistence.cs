using Abner_WebAPI_Backend.Controllers;
using Abner_WebAPI_Backend.Interfaces;
using Abner_WebAPI_Backend.Model;
using Newtonsoft.Json;

namespace Abner_WebAPI_Backend.Persistence
{
    public class ContactPersistence : IContactService
    {
        public static string Path = "C:\\P2\\Asignations\\Abner_WebAPI_Backend\\Json\\Contactjson.json";

        public static void SaveJson(int userId)
        {
            var user = UserController.UserList.FirstOrDefault(u => u.userid == userId);
            if (user != null)
            {
                var Json = JsonConvert.SerializeObject(user.Contacts, Formatting.Indented);
                File.WriteAllText(Path, Json);
            }
        }

        public static void ReadJson(int userId)
        {
            if (File.Exists(Path))
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    string json = reader.ReadToEnd();
                    var contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json);
                    var user = UserController.UserList.FirstOrDefault(u => u.userid == userId);

                    if (user != null)
                    {
                        user.Contacts = contacts ?? new List<ContactModel>();
                    }
                }
            }
            else
            {
                File.CreateText(Path).Close();
            }
        }
    }
}
