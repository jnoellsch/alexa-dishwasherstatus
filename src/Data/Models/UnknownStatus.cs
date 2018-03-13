namespace Alexa.Data.Models
{
    /// <summary>
    /// The unknown or initial status. Crap...need more info.
    /// </summary>
    public class UnknownStatus : Status
    {
        public override int Code => 0;

        public override string Text => "unknown";
    }
}
