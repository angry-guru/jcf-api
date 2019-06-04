using System;
using System.Threading.Tasks;
using jcf_api.Services;
using jcf_api.Types;
using Microsoft.AspNetCore.Mvc;

namespace jcf_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmissionController : ControllerBase
    {
        private readonly EmissionService emissionService;

        public EmissionController(EmissionService emissionService)
        {
            this.emissionService = emissionService ?? throw new ArgumentNullException(nameof(emissionService));
        }

        [HttpPost("{timeOption}/calculate")]
        [ProducesResponseType(typeof(EmissionResponse), 200)]
        public async Task<IActionResult> GetAmountOptions(TimeOption timeOption, [FromBody] EmissionRequest request)
        {
            return Ok(await emissionService.CalculateEmissionResponse(request, timeOption));
        }
    }
}
