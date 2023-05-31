namespace Shimakaze.Events;

public enum OnlineType
{
    FirstOnline,
    ConnectionReset
}

public abstract record OnlineEventArgs : IMEventArgs
{
    public OnlineType Type { get; protected init; }
}
