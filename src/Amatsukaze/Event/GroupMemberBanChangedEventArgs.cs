using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupMemberBanChangedEventArgs : IMEventArgs
{
    public static implicit operator GroupMemberBanChangedEventArgs(CqGroupMemberBanChangedPostContext ctx)=> ;
}
