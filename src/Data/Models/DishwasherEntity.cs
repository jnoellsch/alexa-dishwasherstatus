namespace Alexa.Data.Models
{
    using System;
    using Microsoft.Azure.CosmosDB.Table;

    /// <summary>
    /// A simple model to represent the dishwasher and it's current state.
    /// </summary>
    public class DishwasherEntity : TableEntity
    {
        public DishwasherEntity()
        {
        }

        public DishwasherEntity(string userId)
        {
            this.PartitionKey = ToPartitionKey(userId);
            this.RowKey = ToRowyKey(userId);
        }
        
        public string UserId => this.RowKey;

        public Status Status { get; set; } = new UnknownStatus();

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Updated { get; set; } = DateTime.UtcNow;

        public static string ToPartitionKey(string userId)
        {
            bool hasValue = !string.IsNullOrEmpty(userId) && userId.Length >= 1;
            return hasValue ? userId.Substring(0, 1) : userId;
        }

        public static string ToRowyKey(string userId) => userId;
    }
}
