using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupMemberDecreasedEventArgs : IMEventArgs
{
    public static implicit operator GroupMemberDecreasedEventArgs(CqGroupMemberDecreasedPostContext ctx)=> ;
}
