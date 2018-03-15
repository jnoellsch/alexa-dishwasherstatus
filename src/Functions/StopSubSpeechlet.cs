namespace Alexa.Functions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    public class StopSubSpeechlet : ISubSpeechlet
    {
        public async Task<SpeechletResponse> RespondAsync()
        {
            // build message
            var signoffs = new List<string>()
                                   {
                                       "dirty dishes don't get accidentally unloaded.",
                                       "dirty dishes aren't loaded alongside already clean dishes."
                                   };

            string text = $"Remember: with my help, we can ensure {signoffs.Random()}.";

            // respond back
            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                               ShouldEndSession = true
                           };

            return response;    
        }
    }
}