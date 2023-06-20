using System.Collections;

using Amatsukaze.Message.Block;

using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message;
using Shimakaze.Message.Block;

namespace Amatsukaze.Message;
public sealed record class Message : IMessage
{
    private readonly IList<MessageBlock> _blocks = new List<MessageBlock>();

    public Message()
    {
    }

    public Message(IEnumerable<MessageBlock> blocks)
    {
        _blocks = blocks.ToList();
    }

    public IMessageBlock this[int index]
    {
        get => _blocks[index];
        set => _blocks[index] = (MessageBlock)value;
    }

    public int Count => _blocks.Count;

    public void Add(IMessageBlock item)
    {
        _blocks.Add((MessageBlock)item);
    }

    public void Clear()
    {
        _blocks.Clear();
    }

    public bool Contains(IMessageBlock item)
    {
        return _blocks.Contains(item);
    }

    public IEnumerator<IMessageBlock> GetEnumerator()
    {
        return _blocks.GetEnumerator();
    }

    public int IndexOf(IMessageBlock item)
    {
        return _blocks.IndexOf((MessageBlock)item);
    }

    public bool Remove(IMessageBlock item)
    {
        return _blocks.Remove((MessageBlock)item);
    }

    public void RemoveAt(int index)
    {
        _blocks.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_blocks).GetEnumerator();
    }


    public static Message From(CqMessage msg) => new(msg.Select(MessageBlock.From));
    public CqMessage To() => new(_blocks.Select(i => i.To()));
}