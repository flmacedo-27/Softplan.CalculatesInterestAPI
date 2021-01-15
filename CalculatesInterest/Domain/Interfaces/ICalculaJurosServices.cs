using CalculatesInterest.Domain.Entities;
using System.Threading.Tasks;

namespace CalculatesInterest.Domain.Interfaces
{
    public interface ICalculaJurosServices
    {
        Task<CalculaJuros> GetCalculaJuros(decimal valorInicial, int meses);
    }
}
