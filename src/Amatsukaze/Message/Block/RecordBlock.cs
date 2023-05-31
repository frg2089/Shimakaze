namespace Amatsukaze.Message.Block;

public sealed record RecordBlock(string FilePath) : IMessageBlock
{
    public Uri? Url { get; init; }
    public string? MD5 { get; init; }
    public long? Size { get; init; }
    public TimeSpan? Seconds { get; init; }
}

