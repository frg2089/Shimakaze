using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class MusicBlock
{
    public static implicit operator MusicBlock(CqMusicMsg msg) => new();
}