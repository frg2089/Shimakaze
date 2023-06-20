using Amatsukaze.Message.Block;
using Amatsukaze.Model;

using Shimakaze.Message;
using Shimakaze.Message.Block;

namespace Amatsukaze.Message;

public sealed class MessageBuilder : IMessageBuilder
{
    private readonly Message _message = new();
    public IMessageBuilder Add(IMessageBlock block)
    {
        _message.Add(block);
        return this;
    }

    public IMessageBuilder At(string id)
    {
        return Add(new AtBlock()
        {
            User = new User()
            {
                Id = id
            }
        });
    }

    public IMessage Build() => _message;

    public IMessageBuilder Clear()
    {
        _message.Clear();
        return this;
    }

    public IMessageBuilder Face(int faceId)
    {
        return Add(new FaceBlock()
        {
            FaceId = faceId
        });
    }

    public IMessageBuilder Text(string message)
    {
        return Add(new TextBlock() { Content = message });
    }
}