namespace Alexa.Data.Repositories
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.Azure.ServiceBus;
    using Newtonsoft.Json;

    public class WashcycleFollowupQueue
    {
        public WashcycleFollowupQueue()
        {
            this.Client = ServiceBus.CreateClient("washcycle");
            this.PhoneNumbers = CloudConfigurationManager.GetSetting("PhoneNumbers").Split(';');
        }

        public string[] PhoneNumbers { get; set; }

        public IQueueClient Client { get; set; }

        public async Task EnqueueAsync(string userId)
        {
            // create a message for each phone number
            foreach (var phone in this.PhoneNumbers)
            {
                var dto = new WashcycleMessageDto()
                {
                    UserId = userId,
                    CycleCompletesAt = DateTime.Now.Add(TimeSpan.FromMinutes(1)),
                    Phone = phone
                };

                var message = new Message()
                {
                    ContentType = "application/json",
                    MessageId = Guid.NewGuid().ToString(),
                    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto)),
                    TimeToLive = TimeSpan.FromSeconds(10)
                };

                await this.Client.SendAsync(message);

            }

            // wrap it up 
            await this.Client.CloseAsync();
        }
    }
}