using Shimakaze.Model;

namespace Shimakaze.Message.Block;

public interface IAtBlock : IMessageBlock
{
    IUser User { get; }
}