using Shimakaze.Model;

namespace Shimakaze.Message;

public interface IMessage
{
    public DateTime Time { get; protected init; }
    public IUser Sender { get; protected init; }
    public IUser Receiver { get; protected init; }
    public IMessageContent Content { get; protected init; }
}
