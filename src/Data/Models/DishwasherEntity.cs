namespace Alexa.Data.Models
{
    using System;
    using Microsoft.Azure.CosmosDB.Table;

    /// <summary>
    /// A simple model to represent the dishwasher and it's current state.
    /// </summary>
    public class DishwasherEntity : TableEntity
    {
        private int _statusCode;
        private Status _status;

        public DishwasherEntity()
        {
            this.Status = new UnknownStatus();
        }

        public DishwasherEntity(string userId) : this()
        {
            this.PartitionKey = ToPartitionKey(userId);
            this.RowKey = ToRowKey(userId);
        }

        [IgnoreProperty]
        public string UserId => this.RowKey;
    
        [IgnoreProperty]
        public Status Status
        {
            get => this._status ?? (this._status = Status.FromCode(this._statusCode));
            set
            {
                this._status = value;
                this._statusCode = value.Code;
            }
        }

        public int StatusCode
        {
            get => this._statusCode;
            set
            {
                this._statusCode = value;
                this._status = Status.FromCode(this._statusCode);
            }
        }
        
        /// <summary>
        /// TODO: The user id coming from Alexa is too long to store in Azure table storage so hacking it to be the first 32 characters.
        /// </summary>
        public static string ToRowKey(string userId)
        {
            string userIdNoPrefix = userId.Replace("amzn1.ask.account.", string.Empty);
            return userIdNoPrefix.Substring(0, 32);
        }

        public static string ToPartitionKey(string userId) => ToRowKey(userId).Substring(0, 1);
    }
}
