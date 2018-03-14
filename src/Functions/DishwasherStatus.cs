namespace Alexa.Functions
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;

    public static class DishwasherStatus
    {
        static DishwasherStatus()
        {
            ////ApplicationHelper.Startup();
        }

        [FunctionName("DishwasherStatus")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, 
            TraceWriter log)
        {
            // Get request body
            ////dynamic data = await req.Content.ReadAsAsync<object>();
            ////log.Info($"Alexa request: {data}");

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
