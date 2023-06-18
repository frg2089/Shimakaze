namespace Shimakaze.Event;

public record class IMEventArgs : IIMEventArgs
{
    public static readonly IMEventArgs Empty = new();
    public DateTime CreateTime { get; } = DateTime.Now;
}