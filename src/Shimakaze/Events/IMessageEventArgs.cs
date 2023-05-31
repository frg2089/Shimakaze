using Shimakaze.Message;

namespace Shimakaze.Events;

public interface IMessageEventArgs : IIMEventArgs
{
    IMessage? Message { get; }
}