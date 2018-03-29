namespace Alexa.EventProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Alexa.Data.Repositories;
    using Microsoft.Azure.ServiceBus;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;

    public class Program
    {
        private static IQueueClient queueClient;
        private static ProgramLog log = new ProgramLog();

        public static void Main(string[] args)
        {
            // load settings
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            // start
            MainAsync(configuration).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(IConfigurationRoot configuration)
        {
            // setup client
            log.Start();
            var connectionString = configuration["Values:ServiceBusConnectionString"];
            queueClient = new QueueClient(connectionString, "Values:QueuePath");

            // process messages until keypress
            var options = new MessageHandlerOptions(ExceptionReceivedHandler)
                          {
                              MaxConcurrentCalls = 1, 
                              AutoComplete = false
                          };

            queueClient.RegisterMessageHandler(ProcessMessageHandlerAsync, options);
            Console.ReadKey();

            // cleanup
            await queueClient.CloseAsync();
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs args)
        {
            log.ExceptionOccured(args);

            return Task.CompletedTask;
        }

        private static async Task ProcessMessageHandlerAsync(Message message, CancellationToken cancellationToken)
        {
            var dto = JsonConvert.DeserializeObject<WashcycleMessageDto>(Encoding.UTF8.GetString(message.Body)); 

            log.MessageReceived(dto);

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }
    }
}
