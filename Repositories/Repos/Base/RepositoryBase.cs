using Repositories.DAL;


namespace Repositories.Repos.Base
{
    public abstract class RepositoryBase
    {
        protected ApplicationDbContext _dbContext;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
