﻿namespace Alexa.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Alexa.Data.Models;
    using Alexa.Data.Repositories;
    using AlexaSkillsKit.Speechlet;
    using AlexaSkillsKit.UI;

    /// <summary>
    /// Handles the start intent and as such, sets the dishwasher status to clean.
    /// </summary>
    public class StartResponse : IResponse
    {
        private readonly IDishwasherRepository _repository;

        private readonly Session _session;

        public StartResponse(IDishwasherRepository repository, Session session)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (session == null) throw new ArgumentNullException(nameof(session));

            this._repository = repository;
            this._session = session;
        }

        public async Task<SpeechletResponse> RespondAsync()
        {
            // it's full and/or running so update status to clean (it'll eventually be).
            await this._repository.UpdateStatusAsync(this._session.User.Id, new CleanStatus());
            
            // build message
            var salutations = new List<string>()
                              {
                                  "Thanks for letting me know.",
                                  "Don't be shy when it's time to unload!",
                                  "Splish-splash your dishes are taking a bath."
                              };

            string text = $"Got it. {salutations.Random()}";

            // respond back
            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                               Card = new SimpleCard()
                                      {
                                          Title = "Dishwasher Start",
                                          Content = text
                                      },
                               ShouldEndSession = false
                           };

            return response;    
        }
    }
}