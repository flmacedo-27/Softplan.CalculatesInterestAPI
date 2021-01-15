using CalculatesInterest.Domain.Entities;
using CalculatesInterest.Domain.Interfaces;
using Refit;
using System;
using System.Threading.Tasks;

namespace CalculatesInterest.Domain.Services
{
    public class CalculaJurosServices : ICalculaJurosServices
    {
        public async Task<CalculaJuros> GetCalculaJuros(decimal valorInicial, int meses)
        {
            var taxaJurosClient = RestService.For<ITaxaJurosAPIServices>("https://localhost:44333/");
            var taxaJuros = await taxaJurosClient.GetTaxaJurosAsync();

            return CalculadoraJuros(valorInicial, meses, taxaJuros.Valor);
        }

        private CalculaJuros CalculadoraJuros(decimal valorInicial, int meses, decimal taxaJuros)
        {
            var CalculaJuros = new CalculaJuros();

            var valorFinal = Decimal.Multiply(valorInicial, (decimal)Math.Pow((double)(1 + taxaJuros), meses));
            CalculaJuros.Resultado = decimal.Parse(valorFinal.ToString("##.00"));

            return CalculaJuros;
        }
    }
}
