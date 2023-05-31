namespace Amatsukaze.Message.Block;

public record class ImageBlock(string FilePath) : IComposableBlock
{
    /// <summary>
    /// 网络图片是否使用缓存
    /// </summary>
    public bool UseCache { get; init; }
    /// <summary>
    /// 流的超时时间
    /// </summary>
    public int Timeout { get; init; } = 60;
    public Uri? Url { get; init; }
    public bool AsFace { get; init; }
    public bool ShowOrigin { get; init; }
}

