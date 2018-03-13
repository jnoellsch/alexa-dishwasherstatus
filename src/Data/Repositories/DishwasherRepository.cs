namespace Alexa.Data.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Alexa.Data.Models;
    using Microsoft.Azure.CosmosDB.Table;

    /// <summary>
    /// Handles persisted state management for the dishwasher using Azure table storage.
    /// </summary>
    public class DishwasherRepository : IDishwasherRepository
    {
        private const string TableName = "dishwashers";

        public DishwasherRepository()
        {
            this.DbClient = TableStorageDb.CreateClient();
        }

        private CloudTableClient DbClient { get; }

        public async Task AddAsync(DishwasherEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            // configure table
            var table = await this.DbClient.GetTableAsync(TableName);
            var operation = TableOperation.InsertOrReplace(entity);
            
            await table.ExecuteAsync(operation);
        }

        public async Task<DishwasherEntity> GetByUserAsync(string userId)
        {
            var table = await this.DbClient.GetTableAsync(TableName);
            var operation = TableOperation.Retrieve<DishwasherEntity>(DishwasherEntity.ToPartitionKey(userId), DishwasherEntity.ToRowKey(userId));
            
            var result = await table.ExecuteAsync(operation);
            return result.Result as DishwasherEntity;
        }

        public async Task UpdateStatusAsync(string userId, Status status)
        {
            // hydrate, update
            var dishwasher = await this.GetByUserAsync(userId);
            dishwasher.Status = status;

            // persist
            var table = await this.DbClient.GetTableAsync(TableName);
            var operation = TableOperation.InsertOrReplace(dishwasher);

            await table.ExecuteAsync(operation);
        }
    }
}
