using System.Text.RegularExpressions;

using Shimakaze.Message.Block;

namespace Shimakaze;

public static class MessageBlocksExtensions
{
    public static bool Has(this IEnumerable<IMessageBlock> message, string value) => message.Has(value, StringComparison.OrdinalIgnoreCase);
    public static bool Has(this IEnumerable<IMessageBlock> message, string value, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase) => message.Where(i => i is ITextBlock).Cast<ITextBlock>().Any(i => i.Content.Contains(value, comparisonType));
    public static bool Has(this IEnumerable<IMessageBlock> message, string pattern, RegexOptions options = RegexOptions.None) => message.Where(i => i is ITextBlock).Cast<ITextBlock>().Any(i => Regex.IsMatch(i.Content, pattern, options));
    public static bool Has<TBlock>(this IEnumerable<IMessageBlock> message) where TBlock : IMessageBlock => message.Any(i => i is TBlock);
    public static bool Has<TSpan>(this IEnumerable<IMessageBlock> message, Func<TSpan, bool> matcher) where TSpan : IMessageBlock => message.Any(i => i is TSpan t && matcher(t));

    public static TBlock? Get<TBlock>(this IEnumerable<IMessageBlock> message) where TBlock : IMessageBlock => (TBlock?)message.FirstOrDefault(i => i is TBlock);
    public static TBlock? Get<TBlock>(this IEnumerable<IMessageBlock> message, Func<TBlock, bool> matcher) where TBlock : IMessageBlock => (TBlock?)message.FirstOrDefault(i => i is TBlock t && matcher(t));
}
