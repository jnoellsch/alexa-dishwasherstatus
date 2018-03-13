namespace Alexa.Functions
{
    using System;
    using Alexa.Data.Repositories;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.Slu;

    public class SpeechletFactory
    {
        private readonly Session _session;
        private readonly IDishwasherRepository _repository = new DishwasherRepository();

        public SpeechletFactory(Session session)
        {
            this._session = session ?? throw new ArgumentNullException(nameof(session));
        }
        public ISubSpeechlet CreateWelcome()
        {
            return new WelcomeMessageSubSpeechlet(this._repository, this._session);
        }

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
