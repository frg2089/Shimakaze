using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message.Block;

namespace Amatsukaze.Message.Block;

public sealed record class JsonBlock : MessageBlock, IStringBaseBlock
{
    public required string Content { get; init; }
    public static implicit operator JsonBlock(CqJsonMsg msg) => new()
    {
        Content = msg.Data
    };
}