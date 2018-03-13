namespace Alexa.Data.Models
{
    /// <summary>
    /// The clean status. Unload it!
    /// </summary>
    public class CleanStatus : Status
    {
        public override int Code => 1;

        public override string Text => "clean";
    }
}
