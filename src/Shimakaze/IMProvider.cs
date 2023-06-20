using Shimakaze.Event;
using Shimakaze.Message;
using Shimakaze.Model;

namespace Shimakaze;

public abstract class IMProvider
{
    protected IMProvider(IUser me) => Me = me;

    public IUser Me { get; }
    public event IMEventHandler? Event;
    protected void OnEvent(IIMEventArgs args) => Event?.Invoke(this, args);
    public abstract Task SendFriendAsync(uint id, IMessageBuilder message);
    public abstract Task SendGroupAsync(uint id, IMessageBuilder message);
    public abstract Task<bool> LoginAsync(CancellationToken cancellationToken = default);
    public abstract Task<bool> LogoutAsync(CancellationToken cancellationToken = default);
}