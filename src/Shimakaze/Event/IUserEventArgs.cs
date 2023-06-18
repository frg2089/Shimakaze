using Shimakaze.Model;

namespace Shimakaze.Event;

public interface IUserEventArgs : IIMEventArgs
{
    IUser User { get; }
}