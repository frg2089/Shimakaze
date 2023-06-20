using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class FriendAddedEventArgs : IMEventArgs
{
    public static implicit operator FriendAddedEventArgs(CqFriendAddedPostContext ctx)=> ;
}
