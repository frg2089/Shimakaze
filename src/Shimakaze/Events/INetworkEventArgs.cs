namespace Shimakaze.Events;

public interface INetworkEventArgs : IIMEventArgs
{
    NetworkType Type { get; }
}