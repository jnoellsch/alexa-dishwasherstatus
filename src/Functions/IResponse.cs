namespace Alexa.Functions
{
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;

    public interface ISubSpeechlet
    {
        Task<SpeechletResponse> RespondAsync();
    }
}