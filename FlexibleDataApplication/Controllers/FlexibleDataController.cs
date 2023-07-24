using FlexibleDataApplication.Commands;
using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Queries;
using FlexibleDataApplication.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlexibleDataApplication.Controllers
{
    [ApiController]
    [Route("flexibledata")]
    public class FlexibleDataController : ControllerBase
    {
        private readonly IMediator mediator;

        public FlexibleDataController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("create")]
        public async Task<IActionResult> createFlexibleData(Dictionary<string, string> dict)
        {
            FlexibleData flexibleData;

            try
            {
                var serializedJsonObject = JsonSerializer.Serialize(dict);
                flexibleData = new FlexibleData { Data = serializedJsonObject };

            }catch (Exception ex)
            {
                return BadRequest("Invalid Input");
            }
            //Getting the Created Data
            flexibleData = await mediator.Send(new InsertFlexibleDataCommand(flexibleData));
            await mediator.Send(new UpdateStatsDataCommand(dict));
            return Ok(flexibleData);
        }

        [HttpGet("get/{id?}")]
        public async Task<IActionResult> getFlexibleData(int? id)
        {

            if(!id.HasValue)
            {
                //Getting All felxible Data
                var flexibleData = (await mediator.Send(new GetFlexibleDataListQuery()))
                    .Select(data => JsonSerializer.Deserialize<Dictionary<string, string>>(data.Data)).ToList();

                return Ok(flexibleData);
            }
            else
            {
                //Getting felxible Data
                var flexibleData = await mediator.Send(new GetFlexibleDataByIdQuery(id.Value));
                if (flexibleData == null)
                {
                    return NotFound();
                }

                return Ok(JsonSerializer.Deserialize<Dictionary<string, string>>(flexibleData.Data));
            }  
        }

    }
}
