using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class RedEnvelopeBlock
{
    public static implicit operator RedEnvelopeBlock(CqRedEnvelopeMsg msg)=> ;
}
