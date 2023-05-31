using Shimakaze.Message.Block;

namespace Shimakaze.Message;

public interface IMessageContent : IList<IMessageBlock>
{
}