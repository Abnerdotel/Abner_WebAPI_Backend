using Abner_WebAPI_Backend.Model;

namespace Abner_WebAPI_Backend.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetUsers();
        UserModel Register(UserModel user);
        UserModel Login(UserValidationModel model);
    }
}
