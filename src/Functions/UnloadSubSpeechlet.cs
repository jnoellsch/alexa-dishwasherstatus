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
    /// Handles the unload intent and as such, sets the dishwasher status to dirty.
    /// </summary>
    public class UnloadSubSpeechlet : ISubSpeechlet
    {
        private readonly IDishwasherRepository _repository;
        private readonly Session _session;

        public UnloadSubSpeechlet(IDishwasherRepository repository, Session session)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (session == null) throw new ArgumentNullException(nameof(session));

            this._repository = repository;
            this._session = session;
        }

        public async Task<SpeechletResponse> RespondAsync()
        {
            // it's empty or emptying so update status to dirty.
            await this._repository.UpdateStatusAsync(this._session.User.Id, new DirtyStatus());
            
            // build message
            var salutations = new List<string>()
                              {
                                  "Don't forget to put any existing dirty dishes into the dishwasher.",
                                  "If you see any dirty dishes, why not put those in too.",
                                  "Why not fill it up while you're at it."
                              };

            string text = $"Thanks! {salutations.Random()}";

            // respond back
            var response = new SpeechletResponse
                           {
                               OutputSpeech = new PlainTextOutputSpeech() { Text = text },
                               Card = new SimpleCard()
                                      {
                                          Title = "Dishwasher Unload",
                                          Content = text
                                      },
                               ShouldEndSession = false
                           };

            return response;    
        }
    }
}
