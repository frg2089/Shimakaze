using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupRequestEventArgs : IMEventArgs
{
    public static implicit operator GroupRequestEventArgs(CqGroupRequestPostContext ctx)=> ;
}
