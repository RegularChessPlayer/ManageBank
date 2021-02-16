using AtlanticoBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticoBank.Infrastructure.Data.Repository.Interfaces
{
    public interface ICaixaRepository
    {
        Task<IEnumerable<Caixa>> ListAsync();
        Task AddAsync(Caixa caixa);
        Task<Caixa> FindByIdAsync(long id);
        void Update(Caixa caixa);
        void Remove(Caixa caixa);

    }
}
