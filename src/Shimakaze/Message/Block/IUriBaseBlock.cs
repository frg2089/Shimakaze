namespace Shimakaze.Message.Block;

public interface IUriBaseBlock : IMessageBlock
{
    Uri Uri { get; }
}