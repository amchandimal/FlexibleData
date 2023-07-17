using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Services.Util;

namespace FlexibleDataApplication.Services
{
    public interface IStatisticsService
    {
        Task updateStatistics(string key);
        Task<Statistics> FindById(string key);
        Task<ICollection<Statistics>> GetAll();
        Task updateStats(string key);
    }
}
