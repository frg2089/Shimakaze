using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Shimakaze.Event;
using Shimakaze.Handler;

namespace Shimakaze;

internal sealed class ShimakazeHostedService : IHostedService
{
    private readonly IMProvider _im;
    private readonly ILogger<ShimakazeHostedService> _logger;
    private readonly IServiceProvider _provider;
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public ShimakazeHostedService(IMProvider im, ILogger<ShimakazeHostedService> logger, IServiceProvider provider)
    {
        _im = im;
        _logger = logger;
        _provider = provider;
        _im.Event += OnIMEvent;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        int ms = 5000;
        for (int retry = 1; !await _im.LoginAsync(cancellationToken); retry++)
        {
            if (retry is > 5)
                throw new InvalidOperationException("Login failed");

            ms *= retry;
            _logger.LogError("Login failed, retry after {s}s.", ms / 1000);
            await Task.Delay(ms, cancellationToken);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _cancellationTokenSource.Cancel();
        await _im.LogoutAsync(cancellationToken);
    }

    private async void OnIMEvent(IMProvider sender, IIMEventArgs args)
    {
        _logger.LogDebug("IM Event: {args}", args);

        var types = args.GetType()
            .GetInterfaces()
            .Where(i => i.IsAssignableTo(typeof(IMessageHandler)) && i != typeof(IMessageHandler));

        if (!types.Any())
        {
            _logger.LogWarning("Type \"{type}\" are not implement the Generic IMessageHandler!", args.GetType());
            types = new[] { typeof(IMessageHandler) };
        }

        await using var scope = _provider.CreateAsyncScope();
        var provider = scope.ServiceProvider;

        var handler = types
            .SelectMany(provider.GetServices)
            .Where(o => o is not null)
            .Cast<IMessageHandler>()
            .DistinctBy(h => h.GetType())
            .OrderByDescending(h => h.Weight)
            .FirstOrDefault(i => i.CanExecute(args));

        if (handler is null)
        {
            _logger.LogDebug("We not found any handler can execute. Types: [{types}]", string.Join(", ", types.Select(i => i.Name)));
            return;
        }

        _logger.LogDebug("IM Event Handler: {handler}", handler.GetType());

        try
        {
            await handler.ExecuteAsync(args, _cancellationTokenSource.Token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandler Exception");
        }
    }

}