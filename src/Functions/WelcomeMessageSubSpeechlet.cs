namespace Alexa.Functions
{
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    public class WelcomeMessageSubSpeechlet : ISubSpeechlet
    {
        public async Task<SpeechletResponse> RespondAsync()
        {
            string text = "Welcome to the dishwasher status app. Set the status of the dishwasher by saying the dishes are dirty or the dishes are clean.";

            var speech = new PlainTextOutputSpeech() { Text = text };
            var card = new SimpleCard() { Title = "Welcome!", Content = text };
            var response = new SpeechletResponse { OutputSpeech = speech, Card = card, ShouldEndSession = false };

            return response;
        }
    }
}
