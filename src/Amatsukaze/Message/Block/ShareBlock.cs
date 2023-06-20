using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class ShareBlock
{
    public static implicit operator ShareBlock(CqShareMsg msg)=> ;
}
