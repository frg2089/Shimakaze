using Shimakaze.Event;

namespace Shimakaze.Handler;
public interface IMessageHandler<in TIMEventArgs> : IMessageHandler
    where TIMEventArgs : IIMEventArgs
{
}