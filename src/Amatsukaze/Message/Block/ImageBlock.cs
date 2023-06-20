using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class ImageBlock : MessageBlock
{
    public static implicit operator ImageBlock(CqImageMsg msg) => new();
}