using Microsoft.EntityFrameworkCore;
using NetflixStream.Persistence.Data.Contexts;
using StackExchange.Redis;
using System.Configuration;


namespace NetflixStream.WebAPIs.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabases(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<UserManagementContext>(options =>
                  options.UseSqlServer(
                  configuration.GetConnectionString("NetflixIdentityManagementDatabase"),
                  sqlOptions => sqlOptions.CommandTimeout(300) ));

            services.AddDbContext<NetflixStreamDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("NetflixStreamDb"),
                x => x.MigrationsHistoryTable("_EfMigrations", configuration["Schema:DataSchema"])));

            services.AddSingleton<IConnectionMultiplexer>(s =>
            {
                var connectionString = configuration.GetConnectionString("Redis")?? "localhost:6379";

                var options = ConfigurationOptions.Parse(connectionString);
                
                return ConnectionMultiplexer.Connect(options);
            });
        }
        public static void ConfigureCors(this IServiceCollection services) =>
             services.AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy", builder =>
                 builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
             });
    }
}
