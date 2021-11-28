using Repositories.Contracts.Interfaces;
using Repositories.DAL;
using Repositories.Repos.Base;
using System;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class UnitOfWork : RepositoryBase, IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext dbContext) : base(dbContext) 
        {
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
