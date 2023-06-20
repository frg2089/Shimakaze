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
    public static MessageBlock From(CqMsg msg) => msg switch
    {
        //CqAnonymousMsg anonymous => (AnonymousBlock)anonymous,
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
    public CqMsg To() => this switch
    {
        //AnonymousBlock anonymous => (CqAnonymousMsg)anonymous,
        AtBlock at => (CqAtMsg)at,
        CardImageBlock cardimage => (CqCardImageMsg)cardimage,
        //ContactBlock contact => (CqContactMsg)contact,
        CustomMusicBlock custommusic => (CqCustomMusicMsg)custommusic,
        //DiceBlock dice => (CqDiceMsg)dice,
        FaceBlock face => (CqFaceMsg)face,
        ForwardBlock forward => (CqForwardMsg)forward,
        GiftBlock gift => (CqGiftMsg)gift,
        ImageBlock image => (CqImageMsg)image,
        JsonBlock json => (CqJsonMsg)json,
        //LocationBlock location => (CqLocationMsg)location,
        MusicBlock music => (CqMusicMsg)music,
        PokeBlock poke => (CqPokeMsg)poke,
        RecordBlock record => (CqRecordMsg)record,
        RedEnvelopeBlock redenvelope => (CqRedEnvelopeMsg)redenvelope,
        ReplyBlock reply => (CqReplyMsg)reply,
        //RpsBlock rps => (CqRpsMsg)rps,
        //ShakeBlock shake => (CqShakeMsg)shake,
        ShareBlock share => (CqShareMsg)share,
        TextBlock text => (CqTextMsg)text,
        TtsBlock tts => (CqTtsMsg)tts,
        VideoBlock video => (CqVideoMsg)video,
        XmlBlock xml => (CqXmlMsg)xml,
        _ => throw new InvalidCastException($"Cannot Convert {GetType().FullName} to a CqMsg")
    };
}