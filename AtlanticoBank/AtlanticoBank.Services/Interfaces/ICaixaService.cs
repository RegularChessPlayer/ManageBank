using AtlanticoBank.Domain.Entities;
using AtlanticoBank.Domain.Input;
using AtlanticoBank.Domain.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlanticoBank.Services.Interfaces
{
    public interface ICaixaService
    {
        Task<IEnumerable<Caixa>> ListCaixaAsync();
        IEnumerable<Caixa> ListCaixaSync();
        Task<CaixaResponse> SacarAsync(SaqueInput saqueInput);
        Task<CaixaResponse> SaveCaixaAsync(Caixa caixa);
        Task<CaixaResponse> UpdateCaixaAsync(long id, CaixaInput caixaInput);
        Task<CaixaResponse> DeleteCaixaAsync(long id);

    }
}
