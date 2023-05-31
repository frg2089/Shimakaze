namespace Amatsukaze.Message.Block;

public sealed record PokeBlock(int Id) : IMessageBlock
{
    public string? Text { get; init; }
}

