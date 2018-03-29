namespace Alexa.EventProcessor
{
    using System;
    using System.Threading.Tasks;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;

    public class TwilioTextMessager
    {
        public TwilioTextMessager(TwilioSettings settings, string toPhoneNumber)
        {
            this.Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.To = toPhoneNumber ?? throw new ArgumentNullException(nameof(toPhoneNumber));
        }

        public TwilioSettings Settings { get; }

        public string To { get; }

        public async Task SendMessage(string message)
        {
            TwilioClient.Init(this.Settings.AccountSid, this.Settings.AuthToken);

            await MessageResource.CreateAsync(
                to: this.To, 
                from: this.Settings.From,
                body: message);
        }
    }
}
