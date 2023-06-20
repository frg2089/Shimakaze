using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class ClientStatusChangedEventArgs : IMEventArgs
{
    public static implicit operator ClientStatusChangedEventArgs(CqClientStatusChangedPostContext ctx)=> ;
}
