namespace Alexa.Functions
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;

    /// <summary>
    /// The function endpoint to handle incoming test requests from Alexa to confirm configuration.
    /// </summary>
    public static partial class HelloWorld
    {
        [FunctionName("HelloWorld")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info($"Request={req}");

            return await new HellowWorldSpeechlet().GetResponseAsync(req);
        }
    }
}
