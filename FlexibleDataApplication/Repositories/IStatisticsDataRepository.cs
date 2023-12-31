﻿using FlexibleDataApplication.Entities;

namespace FlexibleDataApplication.Repositories
{
    public interface IStatisticsDataRepository
    {
        Task<Statistics> FindByIdAsync(string key);
        Task<List<Statistics>> GetAllAsync();
        Task<Statistics> UpdateStatistics(Statistics data);
        Task<int> SaveChangesAsync();
    }
}
