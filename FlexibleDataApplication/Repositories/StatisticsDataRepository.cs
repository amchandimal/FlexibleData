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

        public async Task<ICollection<Statistics>> GetAllAsync()
        {
            return await context.Statistics.ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<Statistics> UpdateStatistics(Statistics data)
        {
            context.Statistics.Add(data);
            await context.SaveChangesAsync();
            return data;
        }
    }
}
