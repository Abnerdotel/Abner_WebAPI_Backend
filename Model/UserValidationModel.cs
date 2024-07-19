using Microsoft.EntityFrameworkCore;

namespace Abner_WebAPI_Backend.Model
{
    [Keyless]
    public class UserValidationModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
