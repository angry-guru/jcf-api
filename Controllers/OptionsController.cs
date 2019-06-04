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

        [HttpGet("amount")]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<AmountOption, string>>), 200)]
        public IActionResult GetAmountOptions()
        {
            return Ok(optionsService.GetAmountOptions());
        }

        [HttpGet("time")]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<AmountOption, string>>), 200)]
        public IActionResult GetTimeOptions()
        {
            return Ok(optionsService.GetTimeOptions());
        }
    }
}
