using Lagrange.Core.Common;

namespace Shimakaze.TorpedoLauncher;

public sealed class BotHostedServiceOptions
{
    public BotConfig Config { get; } = new();
    public BotDeviceInfo DeviceInfo { get; init; } = new();
    public BotKeystore Keystore { get; } = new()
    {
        Session = new()
    };
}
