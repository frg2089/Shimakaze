using System.Reflection;
using System.Runtime.Loader;

using Lagrange.Core;
using Lagrange.Core.Common.Interface;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.Core.Core.Event;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Shimakaze.TorpedoLauncher;

public sealed class BotHostedService : IHostedService
{
    private readonly BotContext _client;
    private readonly IConfiguration _configuration;
    private readonly IServiceCollection _services;
    private readonly ILogger<BotHostedService> _logger;
    private readonly AssemblyLoadContext _torpedoArsenal;

    public BotHostedService(BotHostedServiceOptions options, IConfiguration configuration, ILogger<BotHostedService> logger)
    {
        _client = BotFactory.Create(options.Config, options.DeviceInfo, options.Keystore);
        _configuration = configuration;
        _services = new ServiceCollection();
        _services.AddSingleton(new BotMetadata(options.Keystore.Uin, options.Keystore.Uid));
        _logger = logger;
        _torpedoArsenal = new("TorpedoArsenal", true);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Task<bool> login = _client.LoginByPassword();

        _services.AddLogging();
        _services.AddSingleton(_client);
        _services.AddTorpedos(_configuration
            .GetRequiredSection("Torpedos")
            .Get<string[]>()
            ?.Where(path => !string.IsNullOrEmpty(path))
            .Select(torpedo => _torpedoArsenal.LoadFromAssemblyPath(Path.GetFullPath($"{torpedo}.dll")))
            .SelectMany(AssemblyExtensions.GetExportedTypes)
            .Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(ITorpedo)))
            ?? Array.Empty<Type>(),
            _logger
        );

        if (!await login)
            throw new Exception("Login Faild");

        InitializeReceiver();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _torpedoArsenal.Unload();
        return Task.CompletedTask;
    }

    private void InitializeReceiver()
    {
        _client.Invoker.OnBotOnlineEvent += InvokeEvent;
        _client.Invoker.OnBotOfflineEvent += InvokeEvent;
        _client.Invoker.OnBotLogEvent += InvokeEvent;
        _client.Invoker.OnBotCaptchaEvent += InvokeEvent;
        _client.Invoker.OnFriendMessageReceived += InvokeEvent;
        _client.Invoker.OnGroupMessageReceived += InvokeEvent;
        _client.Invoker.OnTempMessageReceived += InvokeEvent;
    }

    private async void InvokeEvent<TEventArgs>(BotContext sender, TEventArgs eventArgs)
        where TEventArgs : EventBase
    {
        await using ServiceProvider provider = _services.BuildServiceProvider();
        IEnumerable<ITorpedo<TEventArgs>> torpedos = provider
            .GetServices<ITorpedo<TEventArgs>>()
            .OrderByDescending(torpedo => torpedo.Weight)
            .Select(torpedo =>
            {
                _logger.LogInformation("Found Torpedo \"{torpedo}\", Weight is {weight}.", torpedo.GetType(), torpedo.Weight);
                return torpedo;
            });

        foreach (var torpedo in torpedos)
        {
            _logger.LogInformation("Torpedo \"{torpedo}\" is Ready, Fire!", torpedo.GetType().FullName);
            await torpedo.ExecuteAsync(eventArgs);
            if (torpedo.End)
            {
                _logger.LogInformation("Torpedo \"{torpedo}\" prevented other torpedoes from being fired.", torpedo.GetType().FullName);
                break;
            }
        }

    }
}
