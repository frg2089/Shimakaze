using Shimakaze.Model;

namespace Amatsukaze.Model;

internal record class User : IUser
{
    internal readonly uint Uid;

    public object Id => Uid;
    public string NickName { get; internal init; } = string.Empty;
    public string Remark { get; internal init; } = string.Empty;
    public Uri Avatar { get; }

    public User(uint id)
    {
        Uid = id;
        Avatar = new($"https://q.qlogo.cn/g?b=qq&nk={Uid}&s=100");
    }
}
