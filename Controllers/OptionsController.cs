using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using jcf_api.Services;
using jcf_api.Types;
using Microsoft.AspNetCore.Mvc;

namespace jcf_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly OptionsService optionsService;

        public OptionsController(OptionsService optionsService)
        {
            this.optionsService = optionsService ?? throw new ArgumentNullException(nameof(optionsService));
        }

        [HttpGet("paper")]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<PaperOption, string>>), 200)]
        public IActionResult GetPaperOptions()
        {
            return Ok(optionsService.GetPaperOptions());
        }

        [HttpGet("flight")]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<PaperOption, string>>), 200)]
        public IActionResult GetFlightOptions()
        {
            return Ok(optionsService.GetFlightOptions());
        }

        [HttpGet("accomodation")]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<PaperOption, string>>), 200)]
        public IActionResult GetAccomodationOptions()
        {
            return Ok(optionsService.GetAccomodationOptions());
        }

        [HttpGet("time")]
        [ProducesResponseType(typeof(IEnumerable<dynamic>), 200)]
        public IActionResult GetTimeOptions()
        {
            return Ok(optionsService.GetTimeOptions());
        }
    }
}
