namespace Alexa.Functions
{
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    /// <summary>
    /// Provides a no words, session-ending repsonse.
    /// </summary>
    public class NoopResponse : IResponse
    {
        public async Task<SpeechletResponse> RespondAsync()
        {
            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = string.Empty },
                               ShouldEndSession = true
                           };

            return response;
        }
    }
}