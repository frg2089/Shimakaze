using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class CustomMusicBlock
{
    public static implicit operator CustomMusicBlock(CqCustomMusicMsg msg)=> ;
}
