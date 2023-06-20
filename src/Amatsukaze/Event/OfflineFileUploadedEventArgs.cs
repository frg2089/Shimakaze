using EleCho.GoCqHttpSdk.Post;

using Shimakaze.Event;

namespace Amatsukaze.Event;

public sealed record class OfflineFileUploadedEventArgs : IMEventArgs
{
    public static implicit operator OfflineFileUploadedEventArgs(CqOfflineFileUploadedPostContext ctx)=> ;
}
