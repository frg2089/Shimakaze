using System.Collections;

using Shimakaze.Model;

namespace Amatsukaze.Model;

internal sealed record class Group : IGroup
{
    internal readonly uint Gid;
    public object Id => Gid;
    internal readonly IReadOnlyList<GroupMember> Members;

    public Group(uint id, IReadOnlyList<GroupMember> members)
    {
        Gid = id;
        Members = members;
        Avatar = new($"https://p.qlogo.cn/gh/{Gid}/{Gid}/spec");
    }

    public IUser this[int index] => Members[index];

    public string Name { get; internal init; } = string.Empty;

    public int MaxCount { get; init; }

    public Uri Avatar { get; }

    public int Count => Members.Count;

    public IEnumerator<IUser> GetEnumerator()
    {
        return Members.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)Members).GetEnumerator();
    }
}