using Shimakaze.Events;

namespace Shimakaze;

public abstract class IMProvider
{
    public event IMEventHandler? Event;
    public abstract Task SendFriendAsync(uint id, MessageBuilder message);
    public abstract Task SendGroupAsync(uint id, MessageBuilder message);
    public abstract Task<bool> LoginAsync(CancellationToken cancellationToken = default);
    public abstract Task<bool> LogoutAsync(CancellationToken cancellationToken = default);
}
