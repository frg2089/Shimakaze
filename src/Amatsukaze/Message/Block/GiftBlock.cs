using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class GiftBlock : MessageBlock
{
    public static implicit operator GiftBlock(CqGiftMsg msg) => new();
}