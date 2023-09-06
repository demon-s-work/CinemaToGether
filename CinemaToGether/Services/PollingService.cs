using CinemaToGether.Abstractions;

namespace CinemaToGether.Services
{
	public class PollingService : PollingServiceBase<IReceiverService>
	{
		public PollingService(IServiceProvider serviceProvider) : base(serviceProvider)
		{
		}
	}
}