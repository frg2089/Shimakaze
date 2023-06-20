using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupMemberNicknameChangedEventArgs : IMEventArgs
{
    public static implicit operator GroupMemberNicknameChangedEventArgs(CqGroupMemberNicknameChangedPostContext ctx)=> ;
}
