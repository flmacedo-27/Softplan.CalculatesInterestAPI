using System.Threading.Tasks;
using CalculatesInterest.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatesInterestAPI.Controllers
{
    [Route("calculaJuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosServices _calculaJurosServices;

        public CalculaJurosController(ICalculaJurosServices calculaJurosServices)
        {
            _calculaJurosServices = calculaJurosServices;
        }

        [HttpGet]
        public async Task<IActionResult> CalculaJuros([FromQuery] decimal valorInicial, int meses)
        {
            var result = await _calculaJurosServices.GetCalculaJuros(valorInicial, meses);

            return Ok(result.Resultado);
        }
    }
}