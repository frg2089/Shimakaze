using Shimakaze.Model;

namespace Shimakaze.Events;

public interface IRequestEventArgs
{
    DateTime RequestTime { get; }
    IUser RequestUser { get; }
    string Description { get; }
}