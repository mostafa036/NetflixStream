namespace NetflixStream.WebAPIs.Extensions
{
    public static class LoggingExtensions
    {
        public static ILoggingBuilder ConfigureLogging(this ILoggingBuilder loggingBuilder)
        {
            // Clear existing providers if needed
            loggingBuilder.ClearProviders();

            // Add Console logging
            loggingBuilder.AddConsole();

            // Set specific logging levels for different namespaces
            loggingBuilder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

            // Additional logging configuration can go here

            return loggingBuilder;
        }
    }
}
