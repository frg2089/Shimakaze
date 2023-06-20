using Amatsukaze.Model;

using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;
using Shimakaze.Message;
using Shimakaze.Model;

namespace Amatsukaze.Event;

public sealed record class PrivateMessageEventArgs : IMEventArgs, IUserEventArgs, IMessageEventArgs
{
    public IMessage? Message { get; init; }

    public required CqHttpUser User { get; init; }

    IUser IUserEventArgs.User => User;
    public static implicit operator PrivateMessageEventArgs(CqPrivateMessagePostContext ctx) => new ()
    {
        User = ctx.Sender,
        Message = ctx.Message
    };
}
