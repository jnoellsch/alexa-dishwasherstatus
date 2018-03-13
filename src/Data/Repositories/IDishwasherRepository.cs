namespace Alexa.Data.Repositories
{
    using System.Threading.Tasks;
    using Alexa.Data.Models;

    /// <summary>
    /// Defines the contract for dishwasher-related data repository operations.
    /// </summary>
    public interface IDishwasherRepository
    {
        void AddAsync(DishwasherEntity entity);

        Task<DishwasherEntity> GetByUserAsync(string userId);

        void UpdateStatusAsync(string userId, Status status);
    }
}