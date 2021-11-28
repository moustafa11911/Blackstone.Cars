using Domains;
using Repositories.Contracts.Interfaces;
using Repositories.DAL;
using Repositories.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Repos
{
    public class RoadRepository : RepositoryBase, IRoadRepository
    {
        public RoadRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        public Road GetById(int id)
        {
            return _dbContext.Roads.Find(id);
        }
    }
}
