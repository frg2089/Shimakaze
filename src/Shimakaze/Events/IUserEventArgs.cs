using Shimakaze.Model;

namespace Shimakaze.Events;

public interface IUserEventArgs : IIMEventArgs
{
    IUser User { get; }
}