using NetflixStream.WebAPIs.Extensions;
using NetflixStream.WebAPIs.Middlewares;
using System.Text.Json.Serialization;

namespace NetflixStream.WebAPIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureDatabases(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration); 
            builder.Services.AddApplicationServicse(builder.Configuration);
            builder.Services.AddDataProtection();
            builder.Services.AddSwaggerServices();
            builder.Services.ConfigureCors();

            // Use the extension method to configure logging
            builder.Logging.ConfigureLogging();
             
            var app = builder.Build();

            // Apply migration and data seeding
            await app.ApplyMigrationsAndSeedDataAsync();
            
            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
                app.UseSwaggerDocumentation();
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            app.UseCors("CORSPolicy");

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication(); 

            app.UseAuthorization();

            app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}