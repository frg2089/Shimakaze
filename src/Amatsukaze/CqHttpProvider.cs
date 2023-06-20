using Amatsukaze.Events;

using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Post;

using Shimakaze;
using Shimakaze.Message;

namespace Amatsukaze;

public sealed class CqHttpProvider : IMProvider
{
    private readonly CqWsSession _session;

    public CqHttpProvider(CqHttpProviderOptions options) : base(options.Account!)
    {
        _session = new(new()
        {
            BaseUri = options.BaseUri,
            UseApiEndPoint = options.UseApiEndPoint,
            UseEventEndPoint = options.UseEventEndPoint,
            AccessToken = options.AccessToken,
            BufferSize = options.BufferSize,
        });
    }

    public override async Task<bool> LoginAsync(CancellationToken cancellationToken = default)
    {
        await _session.StartAsync().ConfigureAwait(false);
        _session.PostPipeline.Use(async (ctx, next) =>
        {
            switch (ctx)
            {
                case CqClientStatusChangedPostContext cqCSC:
                    break;
                case CqFriendAddedPostContext cqFA:
                    break;
                case CqFriendMessageRecalledPostContext cqFMR:
                    break;
                case CqFriendRequestPostContext cqFR:
                    break;
                //case CqGroupAdminChangedPostContext cqGAC:
                //    break;
                case CqGroupEssenceChangedPostContext cqGEC:
                    break;
                case CqGroupFileUploadedPostContext cqGFU:
                    break;
                case CqGroupLuckyKingNoticedPostContext cqGLKN:
                    break;
                case CqGroupMemberBanChangedPostContext cqGMBC:
                    break;
                case CqGroupMemberDecreasedPostContext cqGMD:
                    break;
                case CqGroupMemberHonorChangedPostContext cqGMHC:
                    break;
                case CqGroupMemberIncreasedPostContext cqGMI:
                    break;
                case CqGroupMemberNicknameChangedPostContext cqGMNC:
                    break;
                case CqGroupMemberTitleChangeNoticedPostContext cqGMTCN:
                    break;
                case CqGroupMessagePostContext cqGM:
                    break;
                case CqGroupMessageRecalledPostContext cqGMR:
                    break;
                case CqGroupRequestPostContext cqGR:
                    break;
                case CqHeartbeatPostContext cqH:
                    break;
                case CqLifecyclePostContext cqL:
                    break;
                case CqOfflineFileUploadedPostContext cqOFU:
                    break;
                //case CqPokeNoticedPostContext cqPN:
                //    break;
                case CqPrivateMessagePostContext cqPM:
                    OnEvent(new PrivateMessageEventArgs()
                    {
                        User = cqPM.Sender,
                        Message = cqPM.Message
                    });
                    break;
            }
            await next();
        });
        return true;
    }

    public override async Task<bool> LogoutAsync(CancellationToken cancellationToken = default)
    {
        await _session.StopAsync().ConfigureAwait(false);
        return true;
    }

    public override Task SendFriendAsync(uint id, MessageBuilder message)
    {
        throw new NotImplementedException();
    }

    public override Task SendGroupAsync(uint id, MessageBuilder message)
    {
        throw new NotImplementedException();
    }
}