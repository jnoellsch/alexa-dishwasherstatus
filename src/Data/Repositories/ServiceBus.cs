namespace Alexa.Data.Repositories
{
    using Microsoft.Azure;
    using Microsoft.Azure.ServiceBus;

    public class ServiceBus
    {
        public static IQueueClient CreateClient(string queueName)
        {
            var connectionString = CloudConfigurationManager.GetSetting("ServiceBusConnectionString");
            var client = new QueueClient(connectionString, queueName);
            return client;
        }
    }
}
