using Shimakaze.Message.Block;

namespace Shimakaze.Message;

public abstract class MessageBuilder
{
    public abstract MessageBuilder Add(IMessageBlock span);
    public abstract MessageBuilder Text(string message);
    public abstract MessageBuilder At(uint uin);
    public abstract MessageBuilder Image(byte[] data);
    public virtual MessageBuilder Image(string filePath) => Image(File.ReadAllBytes(filePath));
    public abstract MessageBuilder Face(int faceId);
    public abstract MessageBuilder Clear();
    public abstract IMessageContent Build();
}