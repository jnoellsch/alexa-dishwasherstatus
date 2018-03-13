namespace Alexa.Data.Repositories
{
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.Azure.CosmosDB.Table;
    using Microsoft.Azure.Storage;

    /// <summary>
    /// A set of common code and/or extension methods for Azure-related table storage.
    /// </summary>
    public static class TableStorageDb
    {
        public static CloudTableClient CreateClient()
        {
            var account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            var client = account.CreateCloudTableClient();
            return client;
        }

        public static async Task<CloudTable> GetTableAsync(this CloudTableClient client, string tableName)
        {
            var table = client.GetTableReference(tableName);
            await table.CreateIfNotExistsAsync();
            return table;
        }
    }
}
