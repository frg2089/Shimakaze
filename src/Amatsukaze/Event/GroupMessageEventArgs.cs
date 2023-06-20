using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class GroupMessageEventArgs : IMEventArgs
{
    public static implicit operator GroupMessageEventArgs(CqGroupMessagePostContext ctx)=> ;
}
