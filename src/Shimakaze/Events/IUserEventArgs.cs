using Shimakaze.Model;

namespace Shimakaze.Events;

public interface IUserEventArgs
{
    IUser User { get; }
}
