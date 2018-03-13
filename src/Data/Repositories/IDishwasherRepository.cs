namespace Alexa.Data.Repositories
{
    using System.Threading.Tasks;
    using Alexa.Data.Models;

    /// <summary>
    /// Defines the contract for dishwasher-related data repository operations.
    /// </summary>
    public interface IDishwasherRepository
    {
        Task AddAsync(DishwasherEntity entity);

        Task<DishwasherEntity> GetByUserAsync(string userId);

        Task UpdateStatusAsync(string userId, Status status);
    }
}