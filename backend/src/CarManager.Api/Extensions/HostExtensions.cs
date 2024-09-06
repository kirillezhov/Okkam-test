using Microsoft.EntityFrameworkCore;

namespace CarManager.Api.Extensions;

public static class HostExtensions
{
    public static IHost MigrateDatabase<T>(this IHost host) where T : DbContext
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<T>();

        try
        {
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<T>>();
            logger.LogError(ex, "An error occurred while migrating the database.");
        }

        return host;
    }
}