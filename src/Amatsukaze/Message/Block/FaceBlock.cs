using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class FaceBlock
{
    public static implicit operator FaceBlock(CqFaceMsg msg)=> ;
}
