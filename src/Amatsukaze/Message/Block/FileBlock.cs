namespace Amatsukaze.Message.Block;

public sealed record FileBlock(string Name, string Fid, string MD5, long Size, decimal Duration) : IMessageBlock;

