using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Services.Util;

namespace FlexibleDataApplication.Services
{
    public interface IStatisticsBackgroundService
    {
           Task updateStats(string key);
    }
}
