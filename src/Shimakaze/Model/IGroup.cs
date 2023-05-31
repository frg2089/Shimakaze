namespace Shimakaze.Model;

public interface IGroup : IReadOnlyList<IUser>
{
    uint Id { get; }
    string Name { get; }
    int MaxCount { get; }
    Uri Avatar { get; }
}