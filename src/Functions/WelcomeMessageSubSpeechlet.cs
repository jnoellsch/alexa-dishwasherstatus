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
            string text = "Welcome to the dishwasher status app. Set the status of the dishwasher by saying the dishes are dirty or the dishes are clean.";

            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                               Card = new SimpleCard() { Title = "Welcome!", Content = text },
                               ShouldEndSession = false
                           };

            return response;
        }
    }
}
