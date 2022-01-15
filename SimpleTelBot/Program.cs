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

            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            //ReceiverOptions receiverOptions = new() { AllowedUpdates = { } };
            //Bot.StartReceiving(Handlers.HandleUpdateAsync,
            //                   Handlers.HandleErrorAsync,
            //                   receiverOptions,
            //                   cts.Token);

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();
        }
    }
}
