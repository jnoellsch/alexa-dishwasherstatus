namespace Alexa.Functions
{
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    /// <summary>
    /// A test speechlet that responds with a basic message only.
    /// </summary>
    public class HellowWorldSpeechlet : SpeechletAsync
    {
        public override Task<SpeechletResponse> OnIntentAsync(IntentRequest intentRequest, Session session)
        {
            return Task.FromResult(new SpeechletResponse());
        }

        public override Task<SpeechletResponse> OnLaunchAsync(LaunchRequest launchRequest, Session session)
        {
            string text = "Oh, hello there!";

            var response = new SpeechletResponse
            {
                OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                Card = new SimpleCard() { Title = "Hello!", Content = text },
                ShouldEndSession = false
            };

            return Task.FromResult(response);
        }

        public override Task OnSessionStartedAsync(SessionStartedRequest sessionStartedRequest, Session session)
        {
            return Task.Delay(0);
        }

        public override Task OnSessionEndedAsync(SessionEndedRequest sessionEndedRequest, Session session)
        {
            return Task.Delay(0);
        }
    }
}