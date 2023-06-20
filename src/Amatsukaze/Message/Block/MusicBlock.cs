using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class MusicBlock : MessageBlock
{
    public static implicit operator MusicBlock(CqMusicMsg msg) => new();
}