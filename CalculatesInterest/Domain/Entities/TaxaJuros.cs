using Newtonsoft.Json;

namespace CalculatesInterest.Domain.Entities
{
    public class TaxaJuros
    {
        [JsonProperty("valor")]
        public decimal Valor { get; set; }
    }
}
