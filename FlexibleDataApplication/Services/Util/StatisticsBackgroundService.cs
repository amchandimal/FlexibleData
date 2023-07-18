using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Repositories;
using FlexibleDataApplication.Services.Util;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace FlexibleDataApplication.Services
{
    public class StatisticsBackgroundService : IStatisticsBackgroundService
    {
        private readonly BackgroundWorkerQueue backgroundWorkerQueue;
        private readonly IServiceProvider serviceProvider;

        public StatisticsBackgroundService(BackgroundWorkerQueue backgroundWorkerQueue,
            IServiceProvider serviceProvider)
        {
            this.backgroundWorkerQueue = backgroundWorkerQueue ?? throw new ArgumentNullException(nameof(backgroundWorkerQueue));
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task updateStats(string key)
        {

            backgroundWorkerQueue.QueueBackgroundWorkItem(async token =>
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    //Updating Key Count
                    int KeyCount = 0;
                    HashSet<string> UniqueValues = new HashSet<string>();

                    var allItems = await scope.ServiceProvider.GetRequiredService<IFlexibleDataRepository>().GetAllAsync();
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
                    await scope.ServiceProvider.GetRequiredService<IStatisticsDataRepository>().UpdateStatistics(statistics);
                }
            });
        }
    }
}
