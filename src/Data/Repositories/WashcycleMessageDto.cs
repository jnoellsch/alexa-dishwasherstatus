namespace Alexa.Data.Repositories
{
    using System;

    public class WashcycleMessageDto
    {
        public string UserId { get; set; }

        public DateTime CycleCompletesAt { get; set; }

        public string Phone { get; set; }
    }
}