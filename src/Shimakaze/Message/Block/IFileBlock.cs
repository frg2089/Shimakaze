namespace Shimakaze.Message.Block;

public interface IFileBlock : IUriBaseBlock
{
    string FileName { get; }
    long Size { get; }
}
