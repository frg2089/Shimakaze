using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message.Block;

namespace Amatsukaze.Message.Block;

public sealed record class XmlBlock : MessageBlock, IStringBaseBlock
{
    public required string Content { get; init; }

    public static implicit operator XmlBlock(CqXmlMsg msg) => new()
    {
        Content = msg.Data
    };
}