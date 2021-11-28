using Domains;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts.Interfaces;
using Repositories.DAL;
using Repositories.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class CarRepository : RepositoryBase, ICarRepository
    {
        public CarRepository(ApplicationDbContext dbContext) : base(dbContext){ }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        public Car GetById(int id)
        {
            return _dbContext.Cars.Find(id);
        }
        public void Add(Car car)
        {
            _dbContext.Cars.Add(car);
        }

        public void Delete(Car car)
        {
            _dbContext.Cars.Remove(car);
        }

        public void AddRoad(CarRoad car)
        {
            _dbContext.CarRoads.Add(car);
        }
    }
}
