using FlexibleDataApplication.DbContexts;
using FlexibleDataApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FlexibleDataApplication.Repositories
{
    public class FlexibleDataRepository : IFlexibleDataRepository
    {

        private readonly ApplicationDbContext context;

        public FlexibleDataRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<FlexibleData> AddFlexibleDataAsync(FlexibleData data)
        {
            context.FlexibleData.Add(data);
            await context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var flexibleData = await FindByIdAsync(id);
            if (flexibleData != null)
            {
                context.FlexibleData.Remove(flexibleData);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<FlexibleData> FindByIdAsync(int id)
        {
            return await context.FlexibleData
                .Where(data => data.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<FlexibleData>> GetAllAsync()
        {
            return await context.FlexibleData.ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
