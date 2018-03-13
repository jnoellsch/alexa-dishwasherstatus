namespace Alexa.Data.Models
{
    /// <summary>
    /// The clean status. Unload it!
    /// </summary>
    public class CleanStatus : Status
    {
        public override int Id => 1;

        public override string Value => "clean";
    }
}
