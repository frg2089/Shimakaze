using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupFileUploadedEventArgs : IMEventArgs
{
    public static implicit operator GroupFileUploadedEventArgs(CqGroupFileUploadedPostContext ctx) => new();
}