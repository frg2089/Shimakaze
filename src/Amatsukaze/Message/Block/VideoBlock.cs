namespace Amatsukaze.Message.Block;

public sealed record VideoBlock(string FilePath) : IMessageBlock
{
    public string? Name { get; init; }
    public string? Fid { get; init; }
    public string? MD5 { get; init; }
    public long? Size { get; init; }
    public TimeSpan? Seconds { get; init; }
}

