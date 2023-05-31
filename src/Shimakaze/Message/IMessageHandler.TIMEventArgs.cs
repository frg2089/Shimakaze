using System.ComponentModel;

using Shimakaze.Events;

namespace Shimakaze.Message;
public interface IMessageHandler<in TIMEventArgs> : IMessageHandler
    where TIMEventArgs : IIMEventArgs
{
    bool CanExecute(TIMEventArgs args);
    Task ExecuteAsync(TIMEventArgs args, CancellationToken cancellationToken = default);
}