using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message.Block;

namespace Amatsukaze.Message.Block;

public sealed record class XmlBlock: IStringBaseBlock
{
    public static implicit operator XmlBlock(CqXmlMsg msg)=> ;
}
