using Shimakaze.Events;

namespace Shimakaze.Message;
public interface IMessageHandler<in TIMEventArgs> : IMessageHandler
    where TIMEventArgs : IIMEventArgs
{
}