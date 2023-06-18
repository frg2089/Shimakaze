namespace Shimakaze.Event;

public interface INetworkEventArgs : IIMEventArgs
{
    NetworkType Type { get; }
}