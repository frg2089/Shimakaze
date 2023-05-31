namespace Amatsukaze.Message.Block;

public record class FaceBlock : IComposableBlock
{
    public int Id { get; init; }
    public string? Text { get; init; }
}

