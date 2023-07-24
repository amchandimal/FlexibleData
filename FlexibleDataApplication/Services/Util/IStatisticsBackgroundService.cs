using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Services.Util;

namespace FlexibleDataApplication.Services
{
    public interface IStatisticsBackgroundService
    {
           void UpdateStats(Dictionary<string,string> dict);
    }
}
