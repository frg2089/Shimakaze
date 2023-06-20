﻿using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message.Block;

namespace Amatsukaze.Message.Block;

public sealed record class TextBlock : ITextBlock
{
    public required string Content { get; init; }

    public static implicit operator TextBlock(CqTextMsg msg) => new()
    {
        Content = msg.Text
    };
}
