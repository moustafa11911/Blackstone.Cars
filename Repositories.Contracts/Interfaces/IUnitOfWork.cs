using System.Threading.Tasks;

namespace Repositories.Contracts.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
