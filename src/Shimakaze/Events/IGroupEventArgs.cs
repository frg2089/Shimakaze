using Shimakaze.Model;

namespace Shimakaze.Events;

public interface IGroupEventArgs
{
    IGroup Group { get; }
}
