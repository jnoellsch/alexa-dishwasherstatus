namespace Alexa.Functions
{
    using System;
    using System.Threading.Tasks;
    using Alexa.Data.Models;
    using Alexa.Data.Repositories;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    public class WelcomeMessageSubSpeechlet : ISubSpeechlet
    {
        public async Task<SpeechletResponse> RespondAsync()
        {
            string text = "Welcome to the dishwasher status app. I help people in your home know if the dishes are dirty or clean. " + 
                          "Say 'help' for examples.";

            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                               ShouldEndSession = false
                           };

            return response;
        }
    }
}
