namespace Amatsukaze.Message.Block;

public sealed record ShareBlock(Uri Url, string Title) : IMessageBlock
{
    public string? Content { get; init; }
    public Uri? ImageUri { get; init; }
}

