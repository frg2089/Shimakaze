namespace Shimakaze.Message.Block;

public interface IStringBaseBlock : IMessageBlock
{
    string Content { get; }
}