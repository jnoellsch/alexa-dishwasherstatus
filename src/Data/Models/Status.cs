namespace Alexa.Data.Models
{
    /// <summary>
    /// The common signature for dishwasher status.
    /// </summary>
    public abstract class Status
    {
        public abstract int Id { get; }

        public abstract string Value { get; }
    }
}