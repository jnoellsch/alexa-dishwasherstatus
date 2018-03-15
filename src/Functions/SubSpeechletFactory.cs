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
            return new WelcomeMessageSubSpeechlet();
        }

        public ISubSpeechlet CreateFromIntent(Intent intent)
        {
            var intentName = intent.Name;
            switch (intentName)
            {
                case "RetrieveStateIntent":
                    return new RetrieveStateSubSpeechlet(this._repository, this._session, intent);
                case "UpdateStateIntent":
                    return new UpdateStateSubSpeechlet(this._repository, this._session, intent);
                case "UnloadIntent":
                    return new UnloadSubSpeechlet(this._repository, this._session);
                case "StartIntent":
                    return new StartSubSpeechlet(this._repository, this._session);
                case "AMAZON.StopIntent":
                    return new StopSubSpeechlet();
                case "AMAZON.HelpIntent":
                    return new HelpSubSpeechlet();
                ////case "AMAZON.CancelIntent":
                default:
                    return new FallbackSubSpeechlet();
            }
        }
    }
}
