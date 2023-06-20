using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message;
using Shimakaze.Model;

namespace Amatsukaze.Model;

public sealed record class User : IUser
{
    internal readonly long Uid;

    public string Id
    {
        get => Uid.ToString();
        init => Uid = long.Parse(value);
    }
    public string NickName { get; init; } = string.Empty;
    public Uri? Avatar => new($"https://q1.qlogo.cn/g?b=qq&nk={Id}&s=0");

    public static implicit operator User(CqMessageSender sender) => new()
    {
        Id = sender.UserId.ToString(),
        NickName = sender.Nickname,
    };
}