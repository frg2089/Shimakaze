using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class ReplyBlock : MessageBlock
{
    public static implicit operator ReplyBlock(CqReplyMsg msg) => new();
}