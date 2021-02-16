using AtlanticoBank.Domain.Entities;
using AtlanticoBank.Infrastructure.Data.Context;
using AtlanticoBank.Infrastructure.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlanticoBank.Infrastructure.Data.Repository
{
    public class EstoqueCaixaRepository : BaseRepository, IEstoqueCaixaRepository
    {
        public EstoqueCaixaRepository(DataContext context) : base(context)
        {

        }

        public async Task AddAsync(EstoqueCaixa estoqueCaixa)
        {
            await _context.EstoqueCaixa.AddAsync(estoqueCaixa);
        }

        public async Task<EstoqueCaixa> FindByIdAsync(long id)
        {
            return await _context.EstoqueCaixa.FindAsync(id);
        }

        public async Task<IEnumerable<EstoqueCaixa>> ListAsync(long caixaId)
        {
            return await _context.EstoqueCaixa.Where(ec => ec.CaixaId == caixaId )
                                              .OrderByDescending(ec => ec.Cedula)
                                              .ToListAsync();
        }

        public void Remove(EstoqueCaixa estoqueCaixa)
        {
            _context.EstoqueCaixa.Remove(estoqueCaixa);
        }

        public void Update(EstoqueCaixa estoqueCaixa)
        {
            _context.Update(estoqueCaixa);
        }
    }
}
