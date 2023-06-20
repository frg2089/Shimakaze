using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupMemberHonorChangedEventArgs : IMEventArgs
{
    public static implicit operator GroupMemberHonorChangedEventArgs(CqGroupMemberHonorChangedPostContext ctx) => new();
}