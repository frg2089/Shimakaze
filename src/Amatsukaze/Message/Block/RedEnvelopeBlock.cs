using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class RedEnvelopeBlock : MessageBlock
{
    public static implicit operator RedEnvelopeBlock(CqRedEnvelopeMsg msg) => new();
}