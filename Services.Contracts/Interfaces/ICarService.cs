using Services.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts.Interfaces
{
    public interface ICarService
    {
        public Task<ServiceResult> Add(AddCarRequest request);
        public Task<ServiceResult> RegisterRoad(RegisterRoadRequest request);
        public Task<ServiceResult> PassRoad(PassRoadRequest request);
        public Task<ServiceResult> Edit(int carId, EditCarRequest request);
        public Task<ServiceResult> Delete(int carId);
        public Task<ServiceResult> GetAll();
    }
}
