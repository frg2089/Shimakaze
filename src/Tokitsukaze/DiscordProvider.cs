
using Discord;
using Discord.WebSocket;

using Microsoft.Extensions.Logging;

using Shimakaze;
using Shimakaze.Message;

namespace Tokitsukaze;

public sealed record class DiscordProviderOptions
{
    public string LoginToken { get; set; } = string.Empty;
}

public sealed class DiscordProvider : IMProvider
{
    internal DiscordSocketClient Client;
    internal DiscordProviderOptions Options;
    private readonly ILogger<DiscordProvider>? _logger;

    public DiscordProvider(DiscordSocketClient client, DiscordProviderOptions options, ILogger<DiscordProvider>? logger)
    {
        Client = client;
        Options = options;
        _logger = logger;
    }

    public static DiscordProvider Create()
    {
        DiscordSocketClient client = new();
    }

    public override async Task<bool> LoginAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await Client.LoginAsync(Discord.TokenType.Bot, Options.LoginToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Login fail.");
            return false;
        }
    }

    public override async Task<bool> LogoutAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await Client.LogoutAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Logout fail.");
            return false;
        }
    }

    public override async Task SendFriendAsync(uint id, MessageBuilder message)
    {
        var user = await Client.GetUserAsync(id);
        // user.SendMessageAsync()
    }

    public override Task SendGroupAsync(uint id, MessageBuilder message)
    {
        throw new NotImplementedException();
    }
}