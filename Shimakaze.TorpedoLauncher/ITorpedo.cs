using Lagrange.Core.Core.Event;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Shimakaze.TorpedoLauncher;

public interface ITorpedo
{
    int Weight { get; }
    bool End { get; }
}

public interface ITorpedo<TEventArgs> : ITorpedo where TEventArgs : EventBase
{
    bool CanExecute(TEventArgs eventArgs);
    Task ExecuteAsync(TEventArgs eventArgs);
}

public static class HandlerExtensions
{
    public static IServiceCollection AddTorpedos(this IServiceCollection services, IEnumerable<Type> torpedos, ILogger? logger = default)
    {
        foreach (var torpedo in torpedos)
        {
            foreach (var @interface in torpedo
                .GetInterfaces()
                .Where(i => i.IsAssignableTo(typeof(ITorpedo)) && torpedo != typeof(ITorpedo)))
            {
                logger?.LogInformation("Found Torpedo: \"{type}\" in \"{assembly}\".", torpedo.FullName, torpedo.Assembly.FullName);
                services.AddTransient(@interface, torpedo);
            }
        }

        return services;
    }
}