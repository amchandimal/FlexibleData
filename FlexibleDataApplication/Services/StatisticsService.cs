using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Repositories;
using System.Text.Json;

namespace FlexibleDataApplication.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IFlexibleDataRepository flexibleDataRepository;
        private readonly IStatisticsDataRepository statisticsDataRepository;

        public StatisticsService(IFlexibleDataRepository flexibleDataRepository
            , IStatisticsDataRepository statisticsDataRepository)
        {
            this.flexibleDataRepository = flexibleDataRepository ?? throw new ArgumentNullException(nameof(flexibleDataRepository));
            this.statisticsDataRepository = statisticsDataRepository ?? throw new ArgumentNullException(nameof(statisticsDataRepository));
        }
        public async void updateStatistics(string key)
        {
            //Updating Key Count
            int KeyCount = 0;
            HashSet<string> UniqueValues = new HashSet<string>();

            var allItems = await flexibleDataRepository.GetAllAsync();
            foreach (var flexibleData in allItems)
            {
                var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(flexibleData.Data);
                var value = dict.GetValueOrDefault(key);
                if (value != null)
                {
                    KeyCount++;
                    UniqueValues.Add(value);
                }
            }

            Statistics statistics = new Statistics { Key = key, Count = KeyCount, UniqueCount = UniqueValues.Count };
            await statisticsDataRepository.UpdateStatistics(statistics);
        }
    }
}
