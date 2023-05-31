namespace Amatsukaze.Message.Block;

public sealed record class AtBlock : IComposableBlock
{
    /// <summary>
    /// 是全体成员
    /// </summary>
    public bool IsAll { get; init; }
    /// <summary>
    /// 是频道
    /// </summary>
    public bool IsTiny { get; init; }
    public int Id { get; init; }
    public string? Text { get; init; }
    public bool IsDummy { get; init; }
}

