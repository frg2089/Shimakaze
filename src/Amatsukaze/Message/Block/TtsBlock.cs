using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class TtsBlock : MessageBlock
{
    public static implicit operator TtsBlock(CqTtsMsg msg) => new();
}