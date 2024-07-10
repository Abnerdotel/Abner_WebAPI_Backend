
using Abner_WebAPI_Backend.Interfaces;
using Abner_WebAPI_Backend.Persistence;
using Abner_WebAPI_Backend.Services;

namespace Abner_WebAPI_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Agregando servicios
            //builder.Services.AddScoped<IUserService, UserServices>();
            //builder.Services.AddScoped<IContactService, ContactService>();
            //builder.Services.AddScoped<IRepository<contacto>(sp => new ContactPersistencia<contacto>("C:\\P2\\Asignacioness\\Abner_WebAPI\\json2.json"));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            UserPersistence.Readjson();
            //ContactPersistence.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
