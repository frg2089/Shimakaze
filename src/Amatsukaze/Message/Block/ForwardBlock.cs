using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class ForwardBlock
{
    public static implicit operator ForwardBlock(CqForwardMsg msg) => new();
}