using Shimakaze.Message.Block;

namespace Shimakaze.Events;

public static class MessageEventArgsExtensions
{
    public static IEnumerable<IMessageBlock>? GetBlocks(this IMessageEventArgs message) => message.Message?.Content;
    public static IEnumerable<TBlock>? GetBlocks<TBlock>(this IMessageEventArgs message) where TBlock : IMessageBlock => message.Message?.Content?.Where(i => i is TBlock).Cast<TBlock>();
}