using Shimakaze.Message;

namespace Shimakaze.Event;

public interface IMessageEventArgs : IIMEventArgs
{
    IMessage? Message { get; }
}