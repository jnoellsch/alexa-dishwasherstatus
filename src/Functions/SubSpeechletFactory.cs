namespace Alexa.Functions
{
    using System;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.Slu;

    public class SpeechletFactory
    {
        public ISubSpeechlet CreateFromIntent(Intent intent)
        {
            var intentName = intent.Name;
            switch (intentName)
            {
                case "RetrieveStateIntent":
                    return new RetrieveStateSubSpeechlet(intent);
                case "UpdateStateIntent":
                    return new UpdateStateSubSpeechlet(intent);
                default:
                    throw new SpeechletException($"The intent '{intentName}' was not on the list and was not processed.");
            }
        }
    }
}
