namespace Shimakaze.Message.Block;

public interface IImageBlock : IUriBaseBlock
{
    int Width { get; }
    int Height { get; }
    long Size { get; }
}