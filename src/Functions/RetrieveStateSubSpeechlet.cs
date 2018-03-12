namespace Alexa.Functions
{
    using System;
    using System.Threading.Tasks;
    using AlexaSkillsKit.Slu;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    public class RetrieveStateSubSpeechlet : ISubSpeechlet
    {
        public RetrieveStateSubSpeechlet(Intent intent)
        {
            this.Intent = intent;
        }

        public Intent Intent { get; }

        public async Task<SpeechletResponse> RespondAsync()
        {
            this.Intent.Slots.TryGetValue("State", out var stateSlot);
            string text;

            // if slot mentioned, user is trying to be specific in the ask. 
            // otherwise, it's generic. 
            if (this.SlotWasSpecified(stateSlot))
            {
                string randoYesNo = "yes";
                text = $"You asked if the dishes are {stateSlot?.Value}. The answer is {randoYesNo}.";
            }
            else
            {
                string randoStatus = "clean";
                text = $"You asked about the status of the dishes. The status of your dishwasher is {randoStatus}.";
            }

            var speech = new PlainTextOutputSpeech() { Text = text };
            var card = new SimpleCard() { Title = "Dishwasher Status", Content = text };
            var response = new SpeechletResponse { OutputSpeech = speech, Card = card, ShouldEndSession = false };

            return response;
        }

        private bool SlotWasSpecified(Slot slot) => !string.IsNullOrEmpty(slot?.Value);
    }
}
