namespace Alexa.Functions
{
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    /// <summary>
    /// Handles the default help intent by providing useful examples.
    /// </summary>
    public class HelpSubSpeechlet : ISubSpeechlet
    {
        public async Task<SpeechletResponse> RespondAsync()
        {
            // build message
            string text = "You can set the status of the dishwasher by saying: 'the dishes are dirty'. Or: 'the dishes are clean'. " + 
                          "Retrieve it's status by then asking 'are the dishes dirty'. Or: 'what is the status of the dishwasher'. " + 
                          "You can also just let me know when you are starting the dishwasher or unloading it.";
            
            // respond back
            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                               ShouldEndSession = false
                           };

            return response;
        }
    }
}