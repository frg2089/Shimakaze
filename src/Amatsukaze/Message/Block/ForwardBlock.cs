namespace Amatsukaze.Message.Block;

public sealed record ForwardBlock(int Id, MessageContent Message) : IMessageBlock
{
    public string? NickName { get; init; }
    public DateTime? Time { get; init; }
}

