namespace Shimakaze.Model;

public interface IUser
{
    string Id { get; }
    string NickName { get; }
    string Remark { get; }
    Uri Avatar { get; }
}