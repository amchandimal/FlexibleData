using FlexibleDataApplication.Entities;
using FlexibleDataApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlexibleDataApplication.Controllers
{
    [ApiController]
    [Route("flexibledata")]
    public class FlexibleDataController : ControllerBase
    {
        private readonly IFlexibleDataService flexibleDataService;

        public FlexibleDataController(IFlexibleDataService flexibleDataService)
        {
            this.flexibleDataService = flexibleDataService ?? throw new ArgumentNullException(nameof(flexibleDataService));
        }

        [HttpPost("create")]
        public async Task<IActionResult> createFlexibleData(Dictionary<string, string> dict)
        {
            ICollection<FlexibleData> flexibleData = new List<FlexibleData>();

            try
            {
                var serializedJsonObject = JsonSerializer.Serialize(dict);
                flexibleData.Add(new FlexibleData { Data = serializedJsonObject });

            }catch (Exception ex)
            {
                return BadRequest("Invalid Input");
            }
            //Getting the Created Data
            flexibleData = await flexibleDataService.Save(flexibleData);

            return Ok(flexibleData);
        }

        [HttpGet("get/{id?}")]
        public async Task<IActionResult> getFlexibleData(int id)
        {

            if(id == 0)
            {
                //Getting All felxible Data
                var flexibleData = (await flexibleDataService.GetAll())
                    .Select(data => JsonSerializer.Deserialize<Dictionary<string, string>>(data.Data)).ToList();

                return Ok(flexibleData);
            }
            else
            {
                //Getting felxible Data
                var flexibleData = await flexibleDataService.FindById(id);
                if (flexibleData == null)
                {
                    return NotFound();
                }

                return Ok(JsonSerializer.Deserialize<Dictionary<string, string>>(flexibleData.Data));
            }

            
        }

        //TODO: Remove this after development
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteFelxibleData(int id)
        {

            //Getting felxible Data
            var flexibleData = await flexibleDataService.DeleteById(id);
            if (flexibleData)
            {
                return Ok("Deleted");
            }

            return NotFound();
        }

    }
}
