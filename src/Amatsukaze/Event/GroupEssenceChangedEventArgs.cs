using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupEssenceChangedEventArgs : IMEventArgs
{
    public static implicit operator GroupEssenceChangedEventArgs(CqGroupEssenceChangedPostContext ctx)=> ;
}
