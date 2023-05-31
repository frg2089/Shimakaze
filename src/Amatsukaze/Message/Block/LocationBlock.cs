namespace Amatsukaze.Message.Block;

public sealed record LocationBlock(string Address, decimal Lat, decimal Lng) : IMessageBlock
{
    public string? Id { get; init; }
    public string? Name { get; init; }
}

