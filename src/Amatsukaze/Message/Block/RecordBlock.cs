using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class RecordBlock
{
    public static implicit operator RecordBlock(CqRecordMsg msg) => new();
}