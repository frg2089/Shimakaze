namespace Amatsukaze.Message.Block;

/// <summary>
/// 魔法表情
/// </summary>
/// <param name="Type">rps 猜拳 dice 骰子</param>
public sealed record class MFaceBlock(string Type) : IComposableBlock
{
    public int? Id { get; init; }
}

