using Abner_WebAPI_Backend.Contexto;
using Abner_WebAPI_Backend.Interfaces;
using Abner_WebAPI_Backend.Model;
using Abner_WebAPI_Backend.Persistence;

namespace Abner_WebAPI_Backend.Services
{
    public class UserService : IUserService
    {
        public static List<UserModel> UserList = new();

        private readonly UserContactsDBContext dbContext;

        public UserService(UserContactsDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<UserModel> GetUsers()
        {
            return dbContext.Usuario.ToList();
        }

        public UserModel Register(UserModel user)
        {
            if (UserList.Any(u => u.email == user.email))
                throw new Exception("User already exists.");

            user.userid = UserList.Count > 0 ? UserList.Max(u => u.userid) + 1 : 1;
            UserList.Add(user);
            UserPersistence.SaveJson();
            return user;
        }

        public UserModel Login(UserValidationModel model)
        {
            var user = UserList.FirstOrDefault(u => u.email == model.email);
            if (user == null || user.password != model.password)
                throw new Exception("Invalid credentials.");

            return user;
        }

    }

}
