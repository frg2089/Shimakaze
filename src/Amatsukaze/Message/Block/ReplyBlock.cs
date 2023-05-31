namespace Amatsukaze.Message.Block;

public sealed record ReplyBlock(int Id, DateTime Time, int Seq, int Rand, MessageContent Message) : IMessageBlock;

