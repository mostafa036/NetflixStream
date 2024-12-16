using NetflixStream.Application.MapperProfiles;
using NetflixStream.Application.IServices;
using NetflixStream.Infrastructure.Services;




namespace NetflixStream.WebAPIs.Extensions
{
    public static class ApplicationServicesExtenstions
    {

        public static IServiceCollection AddApplicationServicse(this IServiceCollection services , IConfiguration configuration )
        {

            services.AddSingleton<IConfiguration>(configuration);

            services.Configure<EncryptionSettings>(configuration.GetSection("EncryptionSettings"));


            services.AddScoped<ISubscriptionService , SubscriptionService>();

            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IVideosRespositores<>), typeof(VideosRespositores<>));

            services.AddSingleton(typeof(IFileStorageService),typeof( FileStorageService));

            services.AddSingleton(typeof(ITokenServices),typeof(TokenServices));

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddScoped<MovieService>(); 

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actioncontext) =>
                {
                    var errors = actioncontext.ModelState.Where(M => M.Value?.Errors.Any() == true)
                                                         .SelectMany(E => E.Value.Errors)
                                                         .Select(E => E.ErrorMessage)
                                                         .ToArray();

                    var ValidationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(ValidationErrorResponse);
                };
            }); // Validation Error Response

            return services;
        }
    }
}