using Shimakaze.Model;

namespace Shimakaze.Event;

public interface IMemberEventArgs : IIMEventArgs
{
    IUser Member { get; }
}