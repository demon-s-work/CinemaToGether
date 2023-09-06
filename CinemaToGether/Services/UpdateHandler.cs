using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
namespace CinemaToGether.Services
{
    public class UpdateHandler : IUpdateHandler
    {

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
        }
        
        public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            
        }
    }
}