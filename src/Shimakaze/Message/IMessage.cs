using Shimakaze.Message.Block;

namespace Shimakaze.Message;

public interface IMessage : IEnumerable<IMessageBlock>
{
    IMessageBlock this[int index] { get; set; }

    int Count { get; }

    void Add(IMessageBlock block);
    void Clear();
    bool Contains(IMessageBlock item);
    int IndexOf(IMessageBlock item);
    bool Remove(IMessageBlock item);
    void RemoveAt(int index);
}