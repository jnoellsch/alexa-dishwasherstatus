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

        public async Task<DishwasherEntity> AddAsync(DishwasherEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var table = await this.DbClient.GetTableAsync(TableName);   
            var operation = TableOperation.Insert(entity);

            var result = await table.ExecuteAsync(operation);
            return result.Result as DishwasherEntity;
        }

        public async Task<DishwasherEntity> GetByUserAsync(string userId)
        {
            var table = await this.DbClient.GetTableAsync(TableName);
            var operation = TableOperation.Retrieve<DishwasherEntity>(DishwasherEntity.ToPartitionKey(userId), DishwasherEntity.ToRowKey(userId));
            
            var result = await table.ExecuteAsync(operation);
            var dishwasher = result.Result as DishwasherEntity ?? new DishwasherEntity { Status = new UnknownStatus() };

            return dishwasher;
        }

        public async Task UpdateStatusAsync(string userId, Status status)
        {
            // update
            var dishwasher = new DishwasherEntity(userId) { Status = status };

            // persist
            var table = await this.DbClient.GetTableAsync(TableName);
            var operation = TableOperation.InsertOrMerge(dishwasher);

            await table.ExecuteAsync(operation);
        }
    }
}
