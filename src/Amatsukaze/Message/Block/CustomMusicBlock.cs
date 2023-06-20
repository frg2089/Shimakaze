using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class CustomMusicBlock : MessageBlock
{
    public static implicit operator CustomMusicBlock(CqCustomMusicMsg msg) => new();
}