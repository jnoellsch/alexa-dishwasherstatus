namespace Alexa.Data.Models
{
    /// <summary>
    /// The dirty status. Put more dishes in!
    /// </summary>
    public class DirtyStatus : Status
    {
        public override int Id => 1;

        public override string Value => "dirty";
    }
}
