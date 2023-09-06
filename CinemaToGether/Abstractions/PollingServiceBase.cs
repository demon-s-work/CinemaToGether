using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CinemaToGether.Abstractions
{
	public abstract class PollingServiceBase<TReceiverService> : BackgroundService where TReceiverService : IReceiverService
	{
		protected readonly IServiceProvider _serviceProvider;
		protected readonly ILogger _logger;

		protected PollingServiceBase(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			_logger = _serviceProvider.GetService<ILogger<TReceiverService>>();
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			LogMethodCall();
			while (!stoppingToken.IsCancellationRequested)
			{
				try
				{
					using var scope = _serviceProvider.CreateScope();
					var receiver = scope.ServiceProvider.GetRequiredService<TReceiverService>();

					await receiver.ReceiveAsync(stoppingToken);
				}
				catch (Exception ex)
				{
					_logger.LogError($"Polling failed with exception: {ex}");
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void LogMethodCall()
		{
			var st = new StackTrace();
			var sf = st.GetFrame(1);
			var method = sf.GetMethod();
			_logger.LogInformation($"{method.Name} called");
		}
	}
}