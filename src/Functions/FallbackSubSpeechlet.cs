namespace Alexa.Functions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    /// <summary>
    /// When all other intents fail...
    /// </summary>
    public class FallbackSubSpeechlet : ISubSpeechlet
    {
        public async Task<SpeechletResponse> RespondAsync()
        {
            var sampleUtterances = new List<string>() { "Set the dishwasher status to dirty", "Are the dishes are clean." };

            string text = "Sorry! I don't know how to handle that. Try saying " + sampleUtterances.Random();

            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                               Card = new SimpleCard() { Title = "Dishwasher Whoops!", Content = text },
                               ShouldEndSession = false
                           };

            return await Task.FromResult(response);
        }
    }
}