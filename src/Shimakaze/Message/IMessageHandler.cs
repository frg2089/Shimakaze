using System.ComponentModel;

namespace Shimakaze.Message;

[EditorBrowsable(EditorBrowsableState.Never)]
public interface IMessageHandler
{
    int Weight { get; }
}