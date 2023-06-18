using System.ComponentModel;

using Shimakaze.Event;

namespace Shimakaze.Handler;

[EditorBrowsable(EditorBrowsableState.Never)]
public interface IMessageHandler
{
    int Weight { get; }
    bool CanExecute(IIMEventArgs args);
    Task ExecuteAsync(IIMEventArgs args, CancellationToken cancellationToken = default);
}