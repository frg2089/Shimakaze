using Amatsukaze.Model;

using Microsoft.Extensions.DependencyInjection;

using Shimakaze;

namespace Amatsukaze;
public static class Amatsukaze
{
    public static IServiceCollection AddAmatsukaze(this IServiceCollection services, Action<CqHttpProviderOptions> configuration)
    {
        return services
            .Configure(configuration)
            .AddSingleton<IMProvider, CqHttpProvider>();
    }
}
