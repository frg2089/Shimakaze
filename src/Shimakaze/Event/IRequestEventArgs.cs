using Shimakaze.Model;

namespace Shimakaze.Event;

public interface IRequestEventArgs : IIMEventArgs
{
    DateTime RequestTime { get; }
    IUser RequestUser { get; }
    string Description { get; }
}