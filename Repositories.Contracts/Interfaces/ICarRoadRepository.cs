using Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts.Interfaces
{
    public interface ICarRoadRepository
    {
        void Add(CarRoad carRoad);
        CarRoad Get(int carId, int roadId);

    }
}
