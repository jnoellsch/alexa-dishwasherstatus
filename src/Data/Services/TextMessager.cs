namespace Alexa.Data.Services
{
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;

    public class TextMessager
    {
        public TextMessager(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; }

        public async Task SendMessage(string message)
        {
            TwilioClient.Init(CloudConfigurationManager.GetSetting("TwilioAccountSid"), CloudConfigurationManager.GetSetting("TwilioAuthToken"));

            await MessageResource.CreateAsync(
                to: this.PhoneNumber, 
                body: message);
        }
    }
}
