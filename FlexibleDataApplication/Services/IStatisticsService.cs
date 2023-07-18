﻿using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Services.Util;

namespace FlexibleDataApplication.Services
{
    public interface IStatisticsService
    {
        Task<Statistics> FindById(string key);
        Task<ICollection<Statistics>> GetAll();
    }
}
