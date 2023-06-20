using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class JsonBlock
{
    public static implicit operator JsonBlock(CqJsonMsg msg)=> ;
}
