namespace Alexa.Data.Services
{
    using System;
    using System.Threading.Tasks;
    using Alexa.Data.Models;
    using Alexa.Data.Repositories;

    public class DishwasherService
    {
        private readonly IDishwasherRepository _repository;

        public DishwasherService(IDishwasherRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<DishwasherEntity> AddAsync(DishwasherEntity entity) => await this._repository.AddAsync(entity);

        public async Task<DishwasherEntity> GetByUserAsync(string userId) => await this._repository.GetByUserAsync(userId);

        public async Task UpdateStatusAsync(string userId, Status status)
        {
            await this._repository.UpdateStatusAsync(userId, status);

            // if running, queue a follow up
            if (status is RunningStatus)
            {
                var queue = new WashcycleFollowupQueue();
                await queue.EnqueueAsync(userId);
            }
        }
    }
}
