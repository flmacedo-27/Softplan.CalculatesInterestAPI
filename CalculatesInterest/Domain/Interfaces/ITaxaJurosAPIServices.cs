using CalculatesInterest.Domain.Entities;
using Refit;
using System.Threading.Tasks;

namespace CalculatesInterest.Domain.Interfaces
{
    public interface ITaxaJurosAPIServices
    {
        [Get("/taxaJuros")]
        Task<TaxaJuros> GetTaxaJurosAsync();
    }
}
