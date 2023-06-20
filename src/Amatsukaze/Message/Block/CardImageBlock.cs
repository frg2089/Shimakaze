using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class CardImageBlock
{
    public static implicit operator CardImageBlock(CqCardImageMsg msg)=> ;
}
