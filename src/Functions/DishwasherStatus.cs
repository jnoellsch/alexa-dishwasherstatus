namespace Alexa.Functions
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;

    /// <summary>
    /// The function endpoint to handle incoming requests from Alexa for managing the dishwasher status.
    /// </summary>
    public static class DishwasherStatus
    {
        [FunctionName("DishwasherStatus")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, 
            TraceWriter log)
        {
            // Run speechlet
            try
            {
                var speechlet = new DishwasherStatusSpeechlet(log);
                return await speechlet.GetResponseAsync(req);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
