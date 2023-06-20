

using System.Collections;
using System.Collections.Immutable;

using Amatsukaze.Message.Block;

using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message;
using Shimakaze.Message.Block;
using Shimakaze.Model;

namespace Amatsukaze.Message;
public sealed record class Message : IMessage
{
    private readonly IList<IMessageBlock> _blocks = new List<IMessageBlock>();

    public Message(IEnumerable<MessageBlock> blocks)
    {
        _blocks = blocks.Cast<IMessageBlock>().ToList();
    }

    public IMessageBlock this[int index] { get => _blocks[index]; set => _blocks[index] = value; }

    public int Count => _blocks.Count;

    public bool IsReadOnly => _blocks.IsReadOnly;

    public void Add(IMessageBlock item)
    {
        _blocks.Add(item);
    }

    public void Clear()
    {
        _blocks.Clear();
    }

    public bool Contains(IMessageBlock item)
    {
        return _blocks.Contains(item);
    }

    public void CopyTo(IMessageBlock[] array, int arrayIndex)
    {
        _blocks.CopyTo(array, arrayIndex);
    }

    public IEnumerator<IMessageBlock> GetEnumerator()
    {
        return _blocks.GetEnumerator();
    }

    public int IndexOf(IMessageBlock item)
    {
        return _blocks.IndexOf(item);
    }

    public void Insert(int index, IMessageBlock item)
    {
        _blocks.Insert(index, item);
    }

    public bool Remove(IMessageBlock item)
    {
        return _blocks.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _blocks.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_blocks).GetEnumerator();
    }


    public static implicit operator Message(CqMessage msg) => new(msg.Cast<MessageBlock>());
}