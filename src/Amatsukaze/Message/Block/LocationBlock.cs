﻿using EleCho.GoCqHttpSdk.Message;

namespace Amatsukaze.Message.Block;

public sealed record class LocationBlock
{
    public static implicit operator LocationBlock(CqLocationMsg msg)=> ;
}