using Domains;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts.Interfaces;
using Repositories.DAL;
using Repositories.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Repos
{
    public class CarRoadRepository : RepositoryBase, ICarRoadRepository
    {
        public CarRoadRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        public void Add(CarRoad carRoad)
        {
            _dbContext.CarRoads.Add(carRoad);
        }

        public CarRoad Get(int carId, int roadId)
        {
            return _dbContext.CarRoads
                .Include(x => x.Card)
                .Include(x => x.Logs)
                .Where(x => x.CarId == carId && x.RoadId == roadId)
                .FirstOrDefault();
        }
    }
}
