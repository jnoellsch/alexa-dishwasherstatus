namespace Alexa.Functions
{
    using AlexaSkillsKit.Speechlet;
    using Microsoft.Azure.WebJobs.Host;

    /// <summary>
    /// Logging specifically for <see cref="DishwasherStatusSpeechlet"/>.
    /// </summary>
    public class DishwasherStatusLogger
    {
        public DishwasherStatusLogger(TraceWriter logWriter)
        {
            this.LogWriter = logWriter;
        }

        private TraceWriter LogWriter { get; }

        public void LaunchStart(LaunchRequest request, Session session)
        {
            this.LogWriter.Info($"Launching: requestId={request.RequestId}, sessionId={session.SessionId}");
        }

        public void IntentStart(IntentRequest request, Session session)
        {
            this.LogWriter.Info($"Intent: intent={request.Intent.Name} requestId={request.RequestId}, sessionId={session.SessionId}");
        }

        public void SessionStart(SessionStartedRequest request, Session session)
        {
            this.LogWriter.Info($"SessionStarted: requestId={request.RequestId}, sessionId={session.SessionId}");

        }

        public void SessionEnd(SessionEndedRequest request, Session session)
        {
            this.LogWriter.Info($"OnSesionEnded: requestId={request.RequestId}, sesionId={session.SessionId}");
        }
    }
}
