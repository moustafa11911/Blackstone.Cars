using Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.Interfaces
{
    public interface ICarRepository
    {
        void Add(Car car);        
        void Delete(Car car);
        Task<IEnumerable<Car>> GetAll();
        Car GetById(int id);

        // CarRoad
        void AddRoad(CarRoad car);
    }
}
