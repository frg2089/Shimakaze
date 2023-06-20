using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupMemberTitleChangeNoticedEventArgs : IMEventArgs
{
    public static implicit operator GroupMemberTitleChangeNoticedEventArgs(CqGroupMemberTitleChangeNoticedPostContext ctx)=> ;
}
