using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class HeartbeatEventArgs : IMEventArgs
{
    public static implicit operator HeartbeatEventArgs(CqHeartbeatPostContext ctx) => new();
}