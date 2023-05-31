using Shimakaze.Model;

namespace Shimakaze.Events;

public interface IGroupEventArgs : IIMEventArgs
{
    IGroup Group { get; }
}