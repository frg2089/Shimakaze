using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class PokeNoticedEventArgs : IMEventArgs
{
    public static implicit operator PokeNoticedEventArgs(CqPokeNoticedPostContext ctx)=> ;
}
