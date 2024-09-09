using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CarManager.Application.Configuration;

public static class MapsterBuilder
{
    public static void RegisterMapster<T>(this IServiceCollection services)
    {
        services.RegisterMapster(typeof(T));
    }

    /// <summary>
    /// scans the assembly and gets the IRegister, adding the registration to the globalSettings
    /// </summary>
    /// <param name="services"></param>
    /// <param name="types"></param>
    public static void RegisterMapster(this IServiceCollection services, params Type[] types)
    {
        var globalSettings = TypeAdapterConfig.GlobalSettings;

        var assambles = types.Select(t => t.Assembly).ToArray();

        var configurators = globalSettings.Scan(assambles);

        foreach (var configurator in configurators)
        {
            configurator.Register(globalSettings);
        }

        // register the mapper as Singleton service for DI purposes.
        var mapper = new Mapper(globalSettings);
        services.AddSingleton<IMapper>(mapper);
    }
}