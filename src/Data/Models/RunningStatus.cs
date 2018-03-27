namespace Alexa.Data.Models
{
    using System;

    /// <summary>
    /// The washing cycle status. Your dishwasher is running...better catch it!
    /// </summary>
    public class RunningStatus : Status
    {
        public override int Code => 2;

        public override string Text => "running";

        public DateTime CycleCompletesAt { get; set; }
    }
}
