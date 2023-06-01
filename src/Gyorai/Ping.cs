using Microsoft.Extensions.Configuration;

using Shimakaze;
using Shimakaze.Events;
using Shimakaze.Message;
using Shimakaze.Message.Block;

namespace Gyorai;

public sealed class Ping : IMessageHandler<IMessageEventArgs>
{
    private readonly IMProvider _im;
    private readonly MessageBuilder _builder;
    public bool NeedAt { get; set; }
    public string Request { get; set; } = string.Empty;
    public string Response { get; set; } = string.Empty;

    public int Weight { get; } = 0;

    public Ping(IMProvider im, IConfiguration configuration, MessageBuilder builder)
    {
        _im = im;
        configuration.GetSection("Gyorai:Ping").Bind(this);
        _builder = builder;
    }

    public bool CanExecute(IMessageEventArgs args)
    {
        if (args is not IGroupEventArgs or not IUserEventArgs)
            return false;
        if (args is IGroupEventArgs group && NeedAt)
        {
            if (!(args.GetBlocks()?.Has<IAtBlock>(i => i.User.Id == _im.Me.Id) ?? false))
                return false;
        }

        return args.GetBlocks()?.Has(Request) ?? false;
    }


    public async Task ExecuteAsync(IMessageEventArgs args, CancellationToken cancellationToken = default)
    {
        switch (args)
        {
            case IUserEventArgs user:
                await _im.SendFriendAsync(user.User.Id, _builder.Text(Response));
                break;
            case IGroupEventArgs group when args is IMemberEventArgs member:
                await _im.SendGroupAsync(group.Group.Id, _builder.At(member.Member.Id).Text(Response));
                break;
        }
    }
}