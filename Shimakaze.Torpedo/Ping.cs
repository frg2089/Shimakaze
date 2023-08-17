using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.Core.Core.Event.EventArg;
using Lagrange.Core.Message;
using Lagrange.Core.Message.Entity;

using Microsoft.Extensions.Configuration;

using Shimakaze.TorpedoLauncher;

namespace Shimakaze.Torpedo;

public sealed class Ping : ITorpedo<FriendMessageEvent>, ITorpedo<GroupMessageEvent>
{
    private readonly BotContext _client;
    private readonly BotMetadata _metadata;
    private readonly PingOptions _options;

    public int Weight { get; } = 0;
    public bool End { get; } = true;

    public Ping(BotContext client, IConfiguration configuration, BotMetadata metadata)
    {
        _client = client;
        _options = new();
        _metadata = metadata;
        configuration.GetSection("Torpedo:Ping").Bind(_options);
    }

    private bool AtMe(MessageChain chain) => chain.Any(i => i is MentionEntity mention && mention.Uin == _metadata.Uin);
    private static bool Has(MessageChain chain, string value) => chain.Any(i => i is TextEntity text && text.Text.Contains(value));

    public bool CanExecute(FriendMessageEvent args)
    {
        return Has(args.Chain, _options.Request);
    }

    public bool CanExecute(GroupMessageEvent args)
    {
        if (!args.Chain.GroupUin.HasValue)
            return false;

        if (_options.NeedAt)
        {
            if (!AtMe(args.Chain))
                return false;
        }

        return Has(args.Chain, _options.Request);
    }

    public async Task ExecuteAsync(FriendMessageEvent args)
    {
        await _client.SendMessage(MessageBuilder.Friend(args.Chain.FriendUin).Text(_options.Response).Build());
    }

    public async Task ExecuteAsync(GroupMessageEvent args)
    {
        await _client.SendMessage(MessageBuilder.Group(args.Chain.GroupUin!.Value).Text(_options.Response).Build());
    }

    private sealed class PingOptions
    {
        public bool NeedAt { get; set; }
        public string Request { get; set; } = "Ping";
        public string Response { get; set; } = "Pong";
    }
}
