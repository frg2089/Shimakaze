namespace Shimakaze.Events;

public enum OfflineType
{
    UserLoggedOut,
    ServerKickOff,
    NetworkDown
}

public abstract record OfflineEventArgs : IMEventArgs
{
    public OfflineType Type { get; protected init; }
}
