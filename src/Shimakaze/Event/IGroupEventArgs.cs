using Shimakaze.Model;

namespace Shimakaze.Event;

public interface IGroupEventArgs : IIMEventArgs
{
    IGroup Group { get; }
}