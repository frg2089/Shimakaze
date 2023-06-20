using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class VideoBlock : MessageBlock
{
    public static implicit operator VideoBlock(CqVideoMsg msg) => new();
}