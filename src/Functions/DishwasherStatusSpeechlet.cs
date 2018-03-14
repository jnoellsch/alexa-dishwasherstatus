namespace Alexa.Functions
{
    using System;
    using System.Threading.Tasks;
    using AlexaSkillsKit.Authentication;
    using AlexaSkillsKit.Json;
    using AlexaSkillsKit.Speechlet;
    using Microsoft.Azure.WebJobs.Host;

    public class DishwasherStatusSpeechlet : SpeechletAsync
    {
        public DishwasherStatusSpeechlet(TraceWriter logWriter)
        {
            this.Log = new DishwasherStatusLogger(logWriter);
        }
        
        private DishwasherStatusLogger Log { get; }

        public override async Task<SpeechletResponse> OnIntentAsync(IntentRequest intentRequest, Session session)
        {
            this.Log.IntentStart(intentRequest, session);

            var intentSpeechlet = new SpeechletFactory(session).CreateFromIntent(intentRequest.Intent);
            return await intentSpeechlet.RespondAsync();
        }

        public override async Task<SpeechletResponse> OnLaunchAsync(LaunchRequest launchRequest, Session session)
        {
            this.Log.LaunchStart(launchRequest, session);

            var welcomeSpeechlet = new SpeechletFactory(session).CreateWelcome();
            return await welcomeSpeechlet.RespondAsync();
        }

        public override Task OnSessionStartedAsync(SessionStartedRequest sessionStartedRequest, Session session)
        {
            ////this.Log.SessionStart(sessionStartedRequest, session);
            return Task.Delay(0);
        }

        public override Task OnSessionEndedAsync(SessionEndedRequest sessionEndedRequest, Session session)
        {
            ////this.Log.SessionEnd(sessionEndedRequest, session);
            return Task.Delay(0);
        }

        /// <summary>
        /// TODO: Turn request validation back on before going live.
        /// </summary>
        public override bool OnRequestValidation(
            SpeechletRequestValidationResult result,
            DateTime referenceTimeUtc,
            SpeechletRequestEnvelope requestEnvelope)
        {
            return true;
        }
    }
}
