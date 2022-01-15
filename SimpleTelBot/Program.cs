using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
    
namespace SimpleTelBot
{
    class Program
    {
        private static TelegramBotClient Bot;
        static async Task Main(string[] args)
        {
            Bot = new TelegramBotClient("5041987467:AAEF6Jr5z8i9dkbfs6x-qhhs72raHftnFfE");
            User me = await Bot.GetMeAsync();
            Console.Title = me.Username ?? "My awesome Bot";
            Handlers handlers = new();

            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            Bot.StartReceiving(
                handlers.HandleUpdateAsync,
                handlers.HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);


            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();
        }
    }
}
