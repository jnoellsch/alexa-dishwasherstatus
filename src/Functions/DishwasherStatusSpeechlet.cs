namespace Alexa.Functions
{
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using Microsoft.Azure.WebJobs.Host;

    public class DishwasherStatusSpeechlet : SpeechletAsync
    {
        public DishwasherStatusLogger Log { get; }

        public DishwasherStatusSpeechlet(TraceWriter logWriter)
        {
            this.Log = new DishwasherStatusLogger(logWriter);
        }
        
        public override async Task<SpeechletResponse> OnIntentAsync(IntentRequest intentRequest, Session session)
        {
            this.Log.IntentStart(intentRequest, session);

            var factory = new SpeechletFactory();
            var speechlet = factory.CreateFromIntent(intentRequest.Intent);
            return await speechlet.RespondAsync();
        }

        public override async Task<SpeechletResponse> OnLaunchAsync(LaunchRequest launchRequest, Session session)
        {
            this.Log.LaunchStart(launchRequest, session);

            return await new WelcomeMessageSubSpeechlet().RespondAsync();
        }

        public override async Task OnSessionStartedAsync(SessionStartedRequest sessionStartedRequest, Session session)
        {
            this.Log.SessionStart(sessionStartedRequest, session);
        }

        public override async Task OnSessionEndedAsync(SessionEndedRequest sessionEndedRequest, Session session)
        {
            this.Log.SessionEnd(sessionEndedRequest, session);
        }
    }
}
