namespace Shimakaze.Events;

public interface IIMEventArgs
{
    public static readonly IIMEventArgs Empty = IMEventArgs.Empty;
    DateTime CreateTime { get; }
}