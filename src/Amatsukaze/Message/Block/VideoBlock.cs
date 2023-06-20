using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class VideoBlock
{
    public static implicit operator VideoBlock(CqVideoMsg msg)=> ;
}
