using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class FriendMessageRecalledEventArgs : IMEventArgs
{
    public static implicit operator FriendMessageRecalledEventArgs(CqFriendMessageRecalledPostContext ctx) => new();
}