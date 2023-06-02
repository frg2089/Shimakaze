using Shimakaze.Model;

namespace Shimakaze.Message;

public interface IGroupMessage : IMessage
{
    IGroup Group { get; }
}