namespace Alexa.Functions
{
    using System;
    using System.Threading.Tasks;
    using Alexa.Data.Models;
    using Alexa.Data.Repositories;
    using AlexaSkillsKit.Slu;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    public class UpdateStateSubSpeechlet : ISubSpeechlet
    {
        private readonly IDishwasherRepository _repository;
        private readonly Session _session;
        private Intent _intent;

        public UpdateStateSubSpeechlet(IDishwasherRepository repository, Session session, Intent intent)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (intent == null) throw new ArgumentNullException(nameof(intent));

            this._repository = repository;
            this._session = session;
            this._intent = intent;
        }

        public async Task<SpeechletResponse> RespondAsync()
        {
            this._intent.Slots.TryGetValue("State", out var stateSlot);
            string text;

            // update status
            var requestedStatus = stateSlot?.Value;
            await this._repository.UpdateStatusAsync(this._session.User.Id, Status.FromText(requestedStatus));
            
            // build message
            text = $"Dishwasher is now set to {requestedStatus}";

            // respond back to user
            var speech = new PlainTextOutputSpeech() { Text = text };
            var card = new SimpleCard() { Title = "Dishwasher Status Update", Content = text };
            var response = new SpeechletResponse { OutputSpeech = speech, Card = card, ShouldEndSession = false };

            return response;
        }
    }
}