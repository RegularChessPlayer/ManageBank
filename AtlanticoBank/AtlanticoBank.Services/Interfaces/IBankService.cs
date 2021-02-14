using AtlanticoBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticoBank.Services.Interfaces
{
    public interface IBankService
    {
        Task<IEnumerable<Caixa>> ListCaixaAsync();
        Task<IEnumerable<Caixa>> SacarAsync(int value);

    }
}
