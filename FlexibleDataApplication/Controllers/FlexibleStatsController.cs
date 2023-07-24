using FlexibleDataApplication.Queries;
using FlexibleDataApplication.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlexibleDataApplication.Controllers
{
    [ApiController]
    [Route("flexibledata/count")]
    public class FlexibleStatsController : ControllerBase
    {
        private readonly IMediator mediator;

        public FlexibleStatsController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

            [HttpGet("{key?}")]
            public async Task<IActionResult> getFlexibleData(string key=""){

                if (key == "")
                {
                //Getting All felxible Stats
                    return Ok(await mediator.Send(new GetStatsListQuery()));
                }
                else
                {
                    //Getting felxible Data
                    var flexibleStats = await mediator.Send(new GetStatsByIDQuery(key));
                    if (flexibleStats == null)
                    {
                        return NotFound();
                    }

                    return Ok(flexibleStats);
                }
            }

        
    }
}
