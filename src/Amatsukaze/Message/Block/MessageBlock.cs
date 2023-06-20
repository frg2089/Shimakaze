using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EleCho.GoCqHttpSdk.Message;

using Shimakaze.Message.Block;

namespace Amatsukaze.Message.Block;
public abstract record class MessageBlock : IMessageBlock
{
    public static explicit operator MessageBlock(CqMsg msg) => msg switch
    {
        // CqAnonymousMsg anonymous => (AnonymousBlock)anonymous,
        CqAtMsg at => (AtBlock)at,
        CqCardImageMsg cardimage => (CardImageBlock)cardimage,
        //CqContactMsg contact => (ContactBlock)contact,
        CqCustomMusicMsg custommusic => (CustomMusicBlock)custommusic,
        //CqDiceMsg dice => (DiceBlock)dice,
        CqFaceMsg face => (FaceBlock)face,
        CqForwardMsg forward => (ForwardBlock)forward,
        CqGiftMsg gift => (GiftBlock)gift,
        CqImageMsg image => (ImageBlock)image,
        CqJsonMsg json => (JsonBlock)json,
        //CqLocationMsg location => (LocationBlock)location,
        CqMusicMsg music => (MusicBlock)music,
        CqPokeMsg poke => (PokeBlock)poke,
        CqRecordMsg record => (RecordBlock)record,
        CqRedEnvelopeMsg redenvelope => (RedEnvelopeBlock)redenvelope,
        CqReplyMsg reply => (ReplyBlock)reply,
        //CqRpsMsg rps => (RpsBlock)rps,
        //CqShakeMsg shake => (ShakeBlock)shake,
        CqShareMsg share => (ShareBlock)share,
        CqTextMsg text => (TextBlock)text,
        CqTtsMsg tts => (TtsBlock)tts,
        CqVideoMsg video => (VideoBlock)video,
        CqXmlMsg xml => (XmlBlock)xml,
        _ => throw new InvalidCastException($"Cannot Convert {msg.GetType().FullName} to a MessageBlock")
    };
}