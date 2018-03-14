namespace Alexa.Functions
{
    using System;
    using System.Threading.Tasks;
    using Alexa.Data.Repositories;
    using AlexaSkillsKit.Slu;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    /// <summary>
    /// Retrieves the current dishwasher state and responds with the result.
    /// </summary>
    public class RetrieveStateSubSpeechlet : ISubSpeechlet
    {
        private readonly IDishwasherRepository _repository;
        private readonly Session _session;
        private readonly Intent _intent;

        public RetrieveStateSubSpeechlet(IDishwasherRepository repository, Session session, Intent intent)
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

            // retrieve status
            var dishwasher = await this._repository.GetByUserAsync(this._session.User.Id);
            var currentStatus = dishwasher.Status.Text;
            var requestedStatus = stateSlot?.Value;

            // if slot mentioned, user is trying to be specific in the ask. 
            // otherwise, it's generic. 
            if (this.SlotWasSpecified(stateSlot))
            {
                string yesNo = this.YesNoBasedOn(requestedStatus, currentStatus);
                bool shouldNegate = yesNo == "no";

                text = $"{yesNo}. The dishes are {(shouldNegate ? "not" : string.Empty)} {requestedStatus}.";
            }
            else
            {
                text = $"The status of your dishwasher is {currentStatus}.";
            }

            // respond back to user
            var speech = new PlainTextOutputSpeech() { Text = text };
            var card = new SimpleCard() { Title = "Dishwasher Status Retrieve", Content = text };
            var response = new SpeechletResponse { OutputSpeech = speech, Card = card, ShouldEndSession = false };

            return response;
        }

        private bool SlotWasSpecified(Slot slot) => !string.IsNullOrEmpty(slot?.Value);

        private string YesNoBasedOn(string requested, string actual)
        {
            return String.Equals(requested, actual) ? "yes" : "no";
        } 
    }
}
