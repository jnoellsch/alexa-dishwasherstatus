namespace Alexa.Data.Models
{
    /// <summary>
    /// The dirty status. Put more dishes in!
    /// </summary>
    public class DirtyStatus : Status
    {
        public override int Code => 1;

        public override string Text => "dirty";
    }
}
