using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class FaceBlock : MessageBlock
{
    public required int FaceId { get; init; }
    public string? Name { get; init; }


    public static implicit operator FaceBlock(CqFaceMsg msg) => new()
    {
        FaceId = msg.Id,
        Name = CqFaceMsg.GetFaceNameFromId(msg.Id)
    };

    public static implicit operator CqFaceMsg(FaceBlock block) => new(block.FaceId);
}