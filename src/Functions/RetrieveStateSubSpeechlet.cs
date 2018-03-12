namespace Alexa.Functions
{
    using System;
    using System.Threading.Tasks;
    using AlexaSkillsKit.Slu;
    using AlexaSkillsKit.Speechlet;

    public class RetrieveStateSubSpeechlet : ISubSpeechlet
    {
        public RetrieveStateSubSpeechlet(Intent intent)
        {
            this.Intent = intent;
        }

        public Intent Intent { get; }

        public Task<SpeechletResponse> RespondAsync()
        {
            throw new NotImplementedException();
        }
    }
}
