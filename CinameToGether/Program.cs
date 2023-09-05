using System.Text.Json;
using Telegram.Bot;
using CinameToGether.Dal.Context;
using CinameToGether.Dal.Models;

var authToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
if (String.IsNullOrEmpty(authToken))
{
    return;
}

var db = new ApplicationDbContext();

Console.WriteLine(JsonSerializer.Serialize(db.Users));

var botClient = new TelegramBotClient(authToken);

Console.Read();