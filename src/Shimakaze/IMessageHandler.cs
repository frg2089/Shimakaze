using System.ComponentModel;

using Shimakaze.Events;

namespace Shimakaze;

[EditorBrowsable(EditorBrowsableState.Never)]
public interface IMessageHandler
{
    int Weight { get; }
}

public interface IMessageHandler<in TBotEventArgs> : IMessageHandler
    where TBotEventArgs : IMEventArgs
{
    bool CanExecute(TBotEventArgs args);
    Task ExecuteAsync(TBotEventArgs args, CancellationToken cancellationToken = default);
}
