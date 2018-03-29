namespace Alexa.EventProcessor
{
    using System;
    using Alexa.Data.Repositories;
    using Microsoft.Azure.ServiceBus;

    public class ProgramLog
    {
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Dishwasher status queue watcher started!");
        }

        public void MessageReceived(WashcycleMessageDto dto)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Message received!");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"User: {dto.UserId}");
            Console.WriteLine($"Completes at: {dto.CycleCompletesAt}");
            Console.WriteLine($"Phone: {dto.Phone}");
        }

        public void ExceptionOccured(ExceptionReceivedEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Message handler encounted an exception. :'(");
            Console.WriteLine($"{args.Exception}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
