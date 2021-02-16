using AtlanticoBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticoBank.Infrastructure.Data.Repository.Interfaces
{
    public interface IEstoqueCaixaRepository
    {
        Task<IEnumerable<EstoqueCaixa>> ListAsync(long caixaId);
        Task AddAsync(EstoqueCaixa estoqueCaixa);
        Task<EstoqueCaixa> FindByIdAsync(long id);
        void Update(EstoqueCaixa estoqueCaixa);
        void Remove(EstoqueCaixa estoqueCaixa);

    }
}
