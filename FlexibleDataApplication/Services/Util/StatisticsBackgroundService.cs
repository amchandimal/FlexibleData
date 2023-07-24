using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Repositories;
using FlexibleDataApplication.Services.Util;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public void UpdateStats(Dictionary<string, string> dict)
        {

            backgroundWorkerQueue.QueueBackgroundWorkItem(async token =>
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var allItems = await scope.ServiceProvider.GetRequiredService<IFlexibleDataRepository>().GetAllAsync();

                    foreach (var kv in dict)
                    {
                        //Updating Key Count
                        int KeyCount = 0;
                        HashSet<string> UniqueValues = new();

                        foreach (var flexibleData in allItems)
                        {
                            var dataDict = JsonSerializer.Deserialize<Dictionary<string, string>>(flexibleData.Data);
                            var value = dataDict.GetValueOrDefault(kv.Key);
                            if (value != null)
                            {
                                KeyCount++;
                                UniqueValues.Add(value);
                            }                            
                        }
                        Statistics statistics = new Statistics { Key = kv.Key, Count = KeyCount, UniqueCount = UniqueValues.Count };
                        await scope.ServiceProvider.GetRequiredService<IStatisticsDataRepository>().UpdateStatistics(statistics);
                    }
                }
            });
        }
    }
}
