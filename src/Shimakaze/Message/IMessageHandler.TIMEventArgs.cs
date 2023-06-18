using Shimakaze.Event;

namespace Shimakaze.Message;
public interface IMessageHandler<in TIMEventArgs> : IMessageHandler
    where TIMEventArgs : IIMEventArgs
{
}