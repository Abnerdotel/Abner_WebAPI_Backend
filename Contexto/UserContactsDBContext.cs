using Abner_WebAPI_Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Abner_WebAPI_Backend.Contexto
{
    public class UserContactsDBContext: DbContext
    {
        public UserContactsDBContext(DbContextOptions<UserContactsDBContext> db): base(db) { }

        public DbSet<UserModel> Usuario { get; set; } 
        public DbSet<ContactModel> Contact { get; set; }
    }
}
