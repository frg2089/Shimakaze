using Microsoft.Extensions.DependencyInjection;

using Shimakaze.Handler;

namespace Shimakaze;

public static class Shimakaze
{
    public static IServiceCollection AddShimakazeHandler(this IServiceCollection services)
    {
        var types = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(i => i.ExportedTypes)
            .Where(t => t.IsAssignableTo(typeof(IMessageHandler)) && t.IsClass && !t.IsAbstract);

        foreach (var type in types)
        {
            foreach (var @interface in type
                .GetInterfaces()
                .Where(i => i.IsAssignableTo(typeof(IMessageHandler)) && type != typeof(IMessageHandler)))
            {
                services.AddTransient(@interface, type);
            }
        }

        return services;
    }

    public static IServiceCollection AddShimakaze(this IServiceCollection services)
    {
        return services
            .AddShimakazeHandler()
            .AddHostedService<ShimakazeHostedService>();
    }
}
