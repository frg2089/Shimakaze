using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class PokeBlock : MessageBlock
{
    public static implicit operator PokeBlock(CqPokeMsg msg) => new();
}