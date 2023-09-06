using CinemaToGether;
using CinemaToGether.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Telegram.Bot;

await Host.CreateDefaultBuilder(args)
	.ConfigureServices((ctx, services) => {
		services.AddHttpClient("TelegramBot")
			.AddTypedClient<ITelegramBotClient>((client, sp) => {
				var settings = sp.GetService<IOptions<Settings>>();
				if (settings?.Value.Token is null)
				{
					throw new ArgumentNullException($"Token not provided");
				}
				var options = new TelegramBotClientOptions(settings.Value.Token);
				return new TelegramBotClient(options, client);
			});
		services.AddScoped<UpdateHandler>();
		services.Configure<Settings>(ctx.Configuration.GetSection(Settings.Configuration));
		services.AddHostedService<PollingService>();
	})
	.ConfigureAppConfiguration((context, builder) => {
		builder.AddEnvironmentVariables("CTG_");
	})
	.Build()
	.RunAsync();