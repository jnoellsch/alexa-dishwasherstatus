namespace Alexa.Functions
{
    using System;
    using System.Threading.Tasks;
    using Alexa.Data.Models;
    using Alexa.Data.Services;
    using AlexaSkillsKit.Slu;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    /// <summary>
    /// Handes the update state intent and as such, sets the status via the user-supplied value.
    /// </summary>
    public class UpdateStateResponse : IResponse
    {
        private readonly DishwasherService _service;
        private readonly Session _session;
        private Intent _intent;

        public UpdateStateResponse(DishwasherService service, Session session, Intent intent)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (intent == null) throw new ArgumentNullException(nameof(intent));

            this._service = service;
            this._session = session;
            this._intent = intent;
        }

        public async Task<SpeechletResponse> RespondAsync()
        {
            this._intent.Slots.TryGetValue("State", out var stateSlot);
            string text;

            // update status
            var requestedStatus = stateSlot?.Value;
            await this._service.UpdateStatusAsync(this._session.User.Id, Status.FromText(requestedStatus));
            
            // build message
            text = $"Dishwasher is now set to {requestedStatus}";

            // respond back
            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                               Card = new SimpleCard()
                                      {
                                          Title = "Dishwasher Status Update",
                                          Content = text
                                      },
                               ShouldEndSession = false
                           };

            return response;
        }
    }
}