namespace Amatsukaze.Model;

internal sealed record class GroupMember : User
{
    public GroupMember(uint id) : base(id)
    {
    }
}
