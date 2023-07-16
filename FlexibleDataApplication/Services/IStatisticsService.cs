using FlexibleDataApplication.Entities;

namespace FlexibleDataApplication.Services
{
    public interface IStatisticsService
    {
        void updateStatistics(string key);
        Task<Statistics> FindById(int id);
        Task<ICollection<Statistics>> GetAll();
    }
}
