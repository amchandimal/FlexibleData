using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlexibleDataApplication.Controllers
{
    [ApiController]
    [Route("flexibledata")]
    public class FlexibleDataController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> createFlexibleData(string jsonString)
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            foreach (var kv in dict)
            {
                Console.WriteLine(kv.Key + "-" + kv.Value);
            }

            return Ok();
        }

    }
}
