using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Repositories;
using FlexibleDataApplication.Services.Util;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace FlexibleDataApplication.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsDataRepository statisticsDataRepository;
        private readonly BackgroundWorkerQueue backgroundWorkerQueue;
        private readonly IServiceProvider serviceProvider;

        public StatisticsService(IFlexibleDataRepository flexibleDataRepository
            , IStatisticsDataRepository statisticsDataRepository,
            BackgroundWorkerQueue backgroundWorkerQueue, IServiceProvider serviceProvider)
        {
            this.statisticsDataRepository = statisticsDataRepository ?? throw new ArgumentNullException(nameof(statisticsDataRepository));
            this.backgroundWorkerQueue = backgroundWorkerQueue ?? throw new ArgumentNullException(nameof(backgroundWorkerQueue));
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task<Statistics> FindById(string key)
        {
            return await statisticsDataRepository.FindByIdAsync(key);
        }

        public async Task<ICollection<Statistics>> GetAll()
        {
            return await statisticsDataRepository.GetAllAsync();
        }
    }
}
