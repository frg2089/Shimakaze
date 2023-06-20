using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class FriendRequestEventArgs : IMEventArgs
{
    public static implicit operator FriendRequestEventArgs(CqFriendRequestPostContext ctx)=> ;
}
