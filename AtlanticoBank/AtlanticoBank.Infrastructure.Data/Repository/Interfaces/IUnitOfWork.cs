using System.Threading.Tasks;

namespace AtlanticoBank.Infrastructure.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();

    }
}
