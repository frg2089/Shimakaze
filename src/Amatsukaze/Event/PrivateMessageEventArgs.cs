using Amatsukaze.Model;

using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;
using Shimakaze.Message;
using Shimakaze.Model;

namespace Amatsukaze.Event;

public sealed record class PrivateMessageEventArgs : IMEventArgs, IUserEventArgs, IMessageEventArgs
{
    public Message.Message? Message { get; init; }

    public required CqHttpUser User { get; init; }

    IUser IUserEventArgs.User => User;

    IMessage? IMessageEventArgs.Message => Message;

    public static implicit operator PrivateMessageEventArgs(CqPrivateMessagePostContext ctx) => new()
    {
        User = ctx.Sender,
        Message = ctx.Message,
    };
}