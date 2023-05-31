using Shimakaze.Model;

namespace Shimakaze.Events;

public interface IMemberEventArgs : IIMEventArgs
{
    IUser Member { get; }
}