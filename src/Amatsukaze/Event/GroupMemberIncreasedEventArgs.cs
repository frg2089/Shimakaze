using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupMemberIncreasedEventArgs : IMEventArgs
{
    public static implicit operator GroupMemberIncreasedEventArgs(CqGroupMemberIncreasedPostContext ctx)=> ;
}
