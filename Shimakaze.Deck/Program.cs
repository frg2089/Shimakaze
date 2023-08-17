using System.Text;
using System.Text.Json;

using Lagrange.Core.Common;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Shimakaze.TorpedoLauncher;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services
        .AddSingleton(provider =>
        {
            IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
            BotHostedServiceOptions config;
            var options = configuration.GetRequiredSection("Options");
            var deviceInfo = options.GetSection(nameof(config.DeviceInfo));
            try
            {
                config = new()
                {
                    DeviceInfo =
                        {
                            Guid = Guid.Parse(deviceInfo.GetValue<string>("Guid")
                                ?? throw new FormatException("Guid")),
                            MacAddress = Encoding.UTF8.GetBytes(deviceInfo.GetValue<string>("MacAddress")
                                ?? throw new FormatException("MacAddress")),
                            DeviceName = deviceInfo.GetValue<string>("DeviceName")
                                ?? throw new FormatException("DeviceName"),
                            SystemKernel = deviceInfo.GetValue<string>("SystemKernel")
                                ?? throw new FormatException("SystemKernel"),
                            KernelVersion = deviceInfo.GetValue<string>("KernelVersion")
                                ?? throw new FormatException("KernelVersion"),
                        }
                };
            }
            catch
            {
                config = new()
                {
                    DeviceInfo = BotDeviceInfo.GenerateInfo()
                };
                var logger = provider.GetRequiredService<ILogger<Program>>();
                logger.LogWarning("Cannot parsing DeviceInfo, we will generate new one!");
                logger.LogInformation("New DeviceInfo is: {}", JsonSerializer.Serialize(config.DeviceInfo));
            }

            options.Bind(nameof(config.Config), config.Config);
            options.Bind(nameof(config.Keystore), config.Keystore);
            return config;
        })
        .AddHostedService<BotHostedService>())
    .RunConsoleAsync();