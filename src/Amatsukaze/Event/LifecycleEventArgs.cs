using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class LifecycleEventArgs : IMEventArgs
{
    public static implicit operator LifecycleEventArgs(CqLifecyclePostContext ctx) => new();
}