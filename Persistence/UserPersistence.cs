using Abner_WebAPI_Backend.Controllers;
using Abner_WebAPI_Backend.Model;

using Newtonsoft.Json;


namespace Abner_WebAPI_Backend.Persistence
{
    public class UserPersistence
    {
        public static string Path = "C:\\P2\\Asignations\\Abner_WebAPI_Backend\\Json\\Userjson.json";

        public static void SaveJson()
        {
            List<UserModel> usuarios = UserController.UserList;


            var Json = JsonConvert.SerializeObject(usuarios.ToArray(), Formatting.Indented);

            File.WriteAllText(Path, Json);
        }

        public static void Readjson()
        {
            if (File.Exists(Path))
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    string json = reader.ReadToEnd();
                    //Console.WriteLine(json);                       
                    var JsonUsuario = JsonConvert.DeserializeObject<List<UserModel>>(json);
                    foreach (var JUser in JsonUsuario) { UserController.UserList.Add(JUser); }

                }
            }
            else
            {
                File.CreateText(Path);
                
            }
        }
    }
}
