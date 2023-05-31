namespace Shimakaze.Events;

public delegate void IMEventHandler(IMProvider sender, IMEventArgs args);
public record class IMEventArgs
{
    public static readonly IMEventArgs Empty = new();
    public DateTime CreateTime { get; } = DateTime.Now;
}
