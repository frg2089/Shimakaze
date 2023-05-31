namespace Shimakaze.Model;

public interface IUser
{
    uint Id { get; }
    string NickName { get; }
    string Remark { get; }
    Uri Avatar { get; }
}