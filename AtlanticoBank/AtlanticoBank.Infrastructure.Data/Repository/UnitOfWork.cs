using AtlanticoBank.Infrastructure.Data.Context;
using AtlanticoBank.Infrastructure.Data.Repository.Interfaces;
using System.Threading.Tasks;

namespace AtlanticoBank.Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CompleteAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
