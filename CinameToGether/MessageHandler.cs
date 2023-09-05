using Telegram.Bot;
using Telegram.Bot.Types;

namespace CinameToGether
{
    public class MessageHandler
    {
        private readonly ITelegramBotClient _client;

        public MessageHandler(ITelegramBotClient client)
        {
            _client = client;
        }

        public async Task Process(Message message)
        {
            var username = message?.From?.Username;
            if (message != null)
                await _client.SendTextMessageAsync(message.Chat.Id, $"hello {username}");
        }
    }
}