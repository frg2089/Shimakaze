using Shimakaze.Message;

namespace Shimakaze.Events;

public interface IMessageEventArgs
{
    IMessage? Message { get; }
}
