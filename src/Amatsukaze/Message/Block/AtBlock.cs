using Amatsukaze.Model;

using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message.Block;
using Shimakaze.Model;

namespace Amatsukaze.Message.Block;

public sealed record class AtBlock : MessageBlock, IAtBlock
{
    public required User User { get; init; }

    IUser IAtBlock.User => User;

    public static implicit operator AtBlock(CqAtMsg msg) => new()
    {
        User = new()
        {
            Id = msg.Target.ToString(),
            NickName = msg.Name ?? string.Empty,
        }
    };
    public static implicit operator CqAtMsg(AtBlock block) => new(block.User.Uid);
}