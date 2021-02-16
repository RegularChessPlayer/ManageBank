using AtlanticoBank.Domain.Entities;
using AtlanticoBank.Infrastructure.Data.Context;
using AtlanticoBank.Infrastructure.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtlanticoBank.Infrastructure.Data.Repository
{
    public class CaixaRepository : BaseRepository, ICaixaRepository
    {

        public CaixaRepository(DataContext context) : base(context)
        {

        }

        public async Task AddAsync(Caixa caixa)
        {
            await _context.Caixa.AddAsync(caixa);
        }

        public async Task<Caixa> FindByIdAsync(long id)
        {
            return await _context.Caixa.FindAsync(id);
        }

        public async Task<IEnumerable<Caixa>> ListAsync()
        {
            return await _context.Caixa.Include(c => c.EstoqueCaixas).ToListAsync();
        }

        public void Remove(Caixa caixa)
        {
            _context.Caixa.Remove(caixa);
        }

        public void Update(Caixa caixa)
        {
            _context.Update(caixa);
        }
    }
}
