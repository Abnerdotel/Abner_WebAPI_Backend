using Abner_WebAPI_Backend.Interfaces;
using Abner_WebAPI_Backend.Model;

namespace Abner_WebAPI_Backend.Services
{
    public class UserService : IUserService
    {
        public static List<UserModel> ListaUsuario = new();
        public List<UserModel> GetUsers()
        {
            return ListaUsuario;
        }

    }

}
