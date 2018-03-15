namespace Alexa.Functions
{
    using System;
    using Alexa.Data.Repositories;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.Slu;

    /// <summary>
    /// Generates instances of smaller speechlets of functionality and responses based on 
    /// the intent provided from Alexa.
    /// </summary>
    public class SpeechletFactory
    {
        private readonly Session _session;
        private readonly IDishwasherRepository _repository = new DishwasherRepository();

        public SpeechletFactory(Session session)
        {
            this._session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public IResponse CreateWelcome()
        {
            return new WelcomeMessageResponse();
        }

        public IResponse CreateFromIntent(Intent intent)
        {
            var intentName = intent.Name;
            switch (intentName)
            {
                case "RetrieveStateIntent":
                    return new RetrieveStateResponse(this._repository, this._session, intent);
                case "UpdateStateIntent":
                    return new UpdateStateResponse(this._repository, this._session, intent);
                case "UnloadIntent":
                    return new UnloadResponse(this._repository, this._session);
                case "StartIntent":
                    return new StartResponse(this._repository, this._session);
                case "AMAZON.StopIntent":
                    return new StopResponse();
                case "AMAZON.HelpIntent":
                    return new HelpResponse();
                case "AMAZON.CancelIntent":
                    return new NoopResponse();
                // TODO: Handle naming of the dishwasher?
                default:
                    return new FallbackResponse();
            }
        }
    }
}
