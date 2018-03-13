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
        private readonly IDishwasherRepository _repository;
        private readonly Session _session;

        public WelcomeMessageSubSpeechlet(IDishwasherRepository repository, Session session)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (session == null) throw new ArgumentNullException(nameof(session));

            this._repository = repository;
            this._session = session;
        }

        public async Task<SpeechletResponse> RespondAsync()
        {
            // add initial status entry
            var dishwasher = new DishwasherEntity(this._session.User.Id);
            await this._repository.AddAsync(dishwasher);

            // respond back to user
            string text = "Welcome to the dishwasher status app. Set the status of the dishwasher by saying the dishes are dirty or the dishes are clean.";

            var speech = new PlainTextOutputSpeech() { Text = text };
            var card = new SimpleCard() { Title = "Welcome!", Content = text };
            var response = new SpeechletResponse { OutputSpeech = speech, Card = card, ShouldEndSession = false };

            return response;
        }
    }
}
