using Amatsukaze.Message;
using Amatsukaze.Model;

using Microsoft.Extensions.DependencyInjection;

using Shimakaze;
using Shimakaze.Message;

namespace Amatsukaze;
public static class Amatsukaze
{
    public static IServiceCollection AddAmatsukaze(this IServiceCollection services, Action<ProviderOptions> configuration)
    {
        return services
            .Configure(configuration)
            .AddTransient<IMessageBuilder, MessageBuilder>()
            .AddSingleton<IMProvider, Provider>();
    }
}