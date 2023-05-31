using Shimakaze.Model;

namespace Shimakaze.Events;

public interface IRequestEventArgs : IIMEventArgs
{
    DateTime RequestTime { get; }
    IUser RequestUser { get; }
    string Description { get; }
}