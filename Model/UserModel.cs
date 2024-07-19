using System.ComponentModel.DataAnnotations;

namespace Abner_WebAPI_Backend.Model
{
    public class UserModel
    {
        //Atributos para la parte 1
        [Key]
        public int userid { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public List<ContactModel> Contacts { get; set; } = new();

    }
}
