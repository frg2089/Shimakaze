namespace Amatsukaze.Message.Block;

public sealed record XmlBlock(string Data) : IMessageBlock
{
    public int? Id { get; init; }
}

