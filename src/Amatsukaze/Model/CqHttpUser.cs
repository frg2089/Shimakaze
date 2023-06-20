using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message;
using Shimakaze.Model;

namespace Amatsukaze.Model;

public sealed record class CqHttpUser : IUser
{
    public string Id { get; init; } = string.Empty;
    public string NickName { get; init; } = string.Empty;
    public Uri? Avatar => new($"https://q1.qlogo.cn/g?b=qq&nk={Id}&s=0");

    public static implicit operator CqHttpUser(CqMessageSender sender) => new()
    {
        Id = sender.UserId.ToString(),
        NickName = sender.Nickname,
    };
}
