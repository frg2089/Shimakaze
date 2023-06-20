using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupMessageRecalledEventArgs : IMEventArgs
{
    public static implicit operator GroupMessageRecalledEventArgs(CqGroupMessageRecalledPostContext ctx)=> ;
}
