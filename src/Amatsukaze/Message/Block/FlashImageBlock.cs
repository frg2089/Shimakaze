namespace Amatsukaze.Message.Block;

public sealed record FlashImageBlock : ImageBlock
{
    public FlashImageBlock(string filePath) : base(filePath)
    {
    }
}

