using Shimakaze.Message.Block;

namespace Shimakaze.Message;

public interface IMessageBuilder
{
    IMessageBuilder Add(IMessageBlock span);
    IMessageBuilder Text(string message);
    IMessageBuilder At(string id);
    IMessageBuilder Image(byte[] data);
    IMessageBuilder Image(string filePath) => Image(File.ReadAllBytes(filePath));
    IMessageBuilder Face(int faceId);
    IMessageBuilder Clear();
    IMessage Build();
}