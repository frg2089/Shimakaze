using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class ForwardMessage
{
    public static implicit operator ForwardMessage(CqForwardMessage msg) => new();
}