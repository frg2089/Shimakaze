namespace Shimakaze.Model;

public interface IUser
{
    string Id { get; }
    string NickName { get; }
    Uri? Avatar { get; }
}