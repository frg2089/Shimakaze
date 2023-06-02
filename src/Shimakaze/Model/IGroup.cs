namespace Shimakaze.Model;

public interface IGroup : IReadOnlyList<IUser>
{
    string Id { get; }
    string Name { get; }
    int MaxCount { get; }
    Uri Avatar { get; }
}