namespace Alexa.Functions
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;

    public static class HelloWorld
    {
        [FunctionName("HelloWorld")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info($"Request={req}");

            return await new HellowWorldSpeechlet().GetResponseAsync(req);
        }

        public class HellowWorldSpeechlet : SpeechletAsync
        {
            public override async Task<SpeechletResponse> OnIntentAsync(IntentRequest intentRequest, Session session)
            {
                return new SpeechletResponse();
            }

            public override async Task<SpeechletResponse> OnLaunchAsync(LaunchRequest launchRequest, Session session)
            {
                string text = "Oh, hello there!";

                var response = new SpeechletResponse
                               {
                                   OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                                   Card = new SimpleCard() { Title = "Hello!", Content = text },
                                   ShouldEndSession = false
                               };

                return response;
            }

            public override async Task OnSessionStartedAsync(SessionStartedRequest sessionStartedRequest, Session session)
            {
            }

            public override async Task OnSessionEndedAsync(SessionEndedRequest sessionEndedRequest, Session session)
            {
            }
        }
    }
}
