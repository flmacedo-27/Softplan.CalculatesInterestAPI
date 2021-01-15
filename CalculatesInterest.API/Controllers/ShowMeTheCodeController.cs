using CalculatesInterest.CrossCutting;
using Microsoft.AspNetCore.Mvc;

namespace CalculatesInterestAPI.Controllers
{
    [Route("showmethecode")]
    [ApiController]    
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CalculaJurosConstants.CalculaJurosRepository + "\n" + CalculaJurosConstants.TaxaJurosRepository);
        }
    }
}