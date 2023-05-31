namespace Shimakaze.Model;

public interface IUser
{
    object Id { get; }
    string NickName { get; }
    string Remark { get; }
    Uri Avatar { get; }
}
