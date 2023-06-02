using Shimakaze.Model;

namespace Shimakaze.Message;

public interface IMessage
{
    DateTime Time { get; }
    IUser Sender { get; }
    IUser Receiver { get; }
    IMessageContent Content { get; }
}