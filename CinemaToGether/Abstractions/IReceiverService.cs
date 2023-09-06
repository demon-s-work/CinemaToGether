namespace CinemaToGether.Abstractions
{
	public interface IReceiverService
	{
		Task ReceiveAsync(CancellationToken token);
	}
}