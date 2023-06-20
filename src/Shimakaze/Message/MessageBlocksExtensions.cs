using Shimakaze.Message.Block;

namespace Shimakaze.Message;

public static class MessageBlocksExtensions
{
    public static bool Has(this IEnumerable<IMessageBlock> message, string value) => message.Has(value, StringComparison.OrdinalIgnoreCase);
    public static bool Has(this IEnumerable<IMessageBlock> message, string value, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase) => message.Where(i => i is ITextBlock).Cast<ITextBlock>().Any(i => i.Content.Contains(value, comparisonType));
    public static bool Has(this IEnumerable<IMessageBlock> message, Func<ITextBlock, bool> matcher) => message.Where(i => i is ITextBlock).Cast<ITextBlock>().Any(matcher);
    public static bool Has<TBlock>(this IEnumerable<IMessageBlock> message) where TBlock : IMessageBlock => message.Any(i => i is TBlock);
    public static bool Has<TBlock>(this IEnumerable<IMessageBlock> message, Func<TBlock, bool> matcher) where TBlock : IMessageBlock => message.Any(i => i is TBlock t && matcher(t));

    public static TBlock? Get<TBlock>(this IEnumerable<IMessageBlock> message) where TBlock : IMessageBlock => message.Where(i => i is TBlock).Cast<TBlock>().FirstOrDefault();
    public static TBlock? Get<TBlock>(this IEnumerable<IMessageBlock> message, Func<TBlock, bool> matcher) where TBlock : IMessageBlock => message.Where(i => i is TBlock t && matcher(t)).Cast<TBlock>().FirstOrDefault();
}