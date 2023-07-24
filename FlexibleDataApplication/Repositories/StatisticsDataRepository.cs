using FlexibleDataApplication.DbContexts;
using FlexibleDataApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlexibleDataApplication.Repositories
{
    public class StatisticsDataRepository : IStatisticsDataRepository
    {
        private readonly ApplicationDbContext context;

        public StatisticsDataRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Statistics> FindByIdAsync(string key)
        {
            return await context.Statistics
               .Where(data => data.Key == key).FirstOrDefaultAsync();
        }

        public async Task<List<Statistics>> GetAllAsync()
        {
            return await context.Statistics.ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<Statistics> UpdateStatistics(Statistics data)
        {
            if(context.Statistics.Any(e=> e.Key == data.Key))
            {
                context.Statistics.Update(data);
            }
            else
            {
                context.Statistics.Add(data);
            }
            await context.SaveChangesAsync();
            return data;
        }
    }
}
