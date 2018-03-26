namespace Alexa.Functions
{
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    /// <summary>
    /// Handles the start or welcome intent by providing a brief intro.
    /// </summary>
    public class WelcomeMessageResponse : IResponse
    {
        public async Task<SpeechletResponse> RespondAsync()
        {
            string text = "Welcome to dishwasher. I help you track if the dishes are clean or dirty.";

            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                               ShouldEndSession = false
                           };

            return response;
        }
    }
}
