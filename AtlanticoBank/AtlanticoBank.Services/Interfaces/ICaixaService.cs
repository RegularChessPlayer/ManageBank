using AtlanticoBank.Domain.Entities;
using AtlanticoBank.Domain.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlanticoBank.Services.Interfaces
{
    public interface ICaixaService
    {
        Task<IEnumerable<Caixa>> ListCaixaAsync();
        Task<IEnumerable<Caixa>> SacarAsync(int value);
        Task<CaixaResponse> SaveCaixaAsync(Caixa caixa);
        Task<CaixaResponse> UpdateCaixaAsync(long id, Caixa caixa);
        Task<CaixaResponse> DeleteCaixaAsync(long id);

    }
}
