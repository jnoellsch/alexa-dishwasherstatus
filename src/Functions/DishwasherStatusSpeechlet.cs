namespace Alexa.Functions
{
    using System;
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Data.Edm.Validation;

    public class DishwasherStatusSpeechlet : SpeechletAsync
    {
        public TraceWriter Log { get; }

        public DishwasherStatusSpeechlet(TraceWriter log)
        {
            this.Log = log;
        }
        
        public override async Task<SpeechletResponse> OnIntentAsync(IntentRequest intentRequest, Session session)
        {
            this.Log.Info($"OnIntent: intent={intentRequest.Intent.Name} requestId={intentRequest.RequestId}, sessionId={session.SessionId}");

            var factory = new SpeechletFactory();
            var speechlet = factory.CreateFromIntent(intentRequest.Intent);
            return await speechlet.RespondAsync();
        }

        public override async Task<SpeechletResponse> OnLaunchAsync(LaunchRequest launchRequest, Session session)
        {
            this.Log.Info($"OnLaunch: requestId={launchRequest.RequestId}, sessionId={session.SessionId}");
            return await new WelcomeMessageSubSpeechlet().RespondAsync();
        }

        public override Task OnSessionStartedAsync(SessionStartedRequest sessionStartedRequest, Session session)
        {
            this.Log.Info($"OnSessionStarted: requestId={sessionStartedRequest.RequestId}, sessionId={session.SessionId}");
            return null;
        }

        public override Task OnSessionEndedAsync(SessionEndedRequest sessionEndedRequest, Session session)
        {
            this.Log.Info($"OnSesionEnded: requestId={sessionEndedRequest.RequestId}, sesionId={session.SessionId}");
            return null;
        }
    }
}
