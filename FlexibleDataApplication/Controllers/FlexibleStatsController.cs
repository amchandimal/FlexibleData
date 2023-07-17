using FlexibleDataApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlexibleDataApplication.Controllers
{
    [ApiController]
    [Route("flexibledata/count")]
    public class FlexibleStatsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public FlexibleStatsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService ?? throw new ArgumentNullException(nameof(statisticsService));
        }

            [HttpGet("{key?}")]
            public async Task<IActionResult> getFlexibleData(string key=""){

                if (key == "")
                {
                    //Getting All felxible Stats
                    var flexibleStats = await statisticsService.GetAll();
                    return Ok(flexibleStats);
                }
                else
                {
                    //Getting felxible Data
                    var flexibleStats = await statisticsService.FindById(key);
                    if (flexibleStats == null)
                    {
                        return NotFound();
                    }

                    return Ok(flexibleStats);
                }
            }

        
    }
}
