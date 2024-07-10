using Abner_WebAPI_Backend.Model;
using Abner_WebAPI_Backend.Services;
using Newtonsoft.Json;

namespace Abner_WebAPI_Backend.Persistence
{
    public class UserPersistence
    {
        public static string Path = @"C:\\P2\\Asignations\\Abner_WebAPI_Backend\\Json\\Userjson.json";

        public static void guardarJson()
        {
            List<UserModel> usuarios = UserService.ListaUsuario;


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
                    foreach (var JUser in JsonUsuario) { UserService.ListaUsuario.Add(JUser); }

                }
            }
            else
            {
                File.CreateText(Path);
            }
        }
    }
}
