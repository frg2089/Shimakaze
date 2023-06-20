using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupLuckyKingNoticedEventArgs : IMEventArgs
{
    public static implicit operator GroupLuckyKingNoticedEventArgs(CqGroupLuckyKingNoticedPostContext ctx) => new();
}