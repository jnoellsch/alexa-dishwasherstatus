namespace Alexa.Functions
{
    using System.Threading.Tasks;
    using AlexaSkillsKit.Speechlet;

    /// <summary>
    /// Defines the structure for the small speechlets of functionality.
    /// </summary>
    public interface IResponse
    {
        Task<SpeechletResponse> RespondAsync();
    }
}