using AutoMapper;
using Domains;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts.Interfaces;
using Services.Base;
using Services.Contracts;
using Services.Contracts.Dtos;
using Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CarService : ServiceBase, ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IRoadRepository _roadRepository;
        private readonly ICarRoadRepository _carRoadRepository;
        private readonly IConfiguration _config;
        public CarService(IUnitOfWork unitOfWork, ICarRepository carRepository, IRoadRepository roadRepository, ICarRoadRepository carRoadRepository, IConfiguration config, IMapper mapper) : base(unitOfWork, mapper)
        {
            _carRepository = carRepository;
            _roadRepository = roadRepository;
            _config = config;
            _carRoadRepository = carRoadRepository;
        }

        public async Task<ServiceResult> GetAll()
        {
            var cars = await _carRepository.GetAll();
            var result = _mapper.Map<IEnumerable<CarDto>>(cars);
            return Succeeded(result);
        }

        public async Task<ServiceResult> Add(AddCarRequest request)
        {
            var car = new Car
            {
                ModelNumber = request.ModelNumber,
                PlateNumber = request.PlateNumber,
                BrandId = request.BrandId,
                EmployeeId = request.EmployeeId
            };

            _carRepository.Add(car);
            await _unitOfWork.CommitAsync();

            return Succeeded(new AddCarResponse { Id = car.Id });
        }

        public async Task<ServiceResult> Delete(int carId)
        {
            var car = _carRepository.GetById(carId);
            if (car == null)
                return Failed(nameof(carId), $"Invalid CarId '{carId}'");

            _carRepository.Delete(car);
            await _unitOfWork.CommitAsync();

            return Succeeded();
        }

        public async Task<ServiceResult> Edit(int carId, EditCarRequest request)
        {
            var car = _carRepository.GetById(carId);
            if (car == null)
                return Failed(nameof(carId), $"Invalid CarId '{carId}'");

            car.ModelNumber = request.ModelNumber;
            car.PlateNumber = request.PlateNumber;
            car.EmployeeId = request.EmployeeId;
            car.BrandId = request.BrandId;

            await _unitOfWork.CommitAsync();

            return Succeeded();
        }

        public async Task<ServiceResult> RegisterRoad(RegisterRoadRequest request)
        {
            var car = _carRepository.GetById(request.CarId);
            if (car == null)
                return Failed(nameof(request.CarId), $"Invalid CarId'");

            var road = _roadRepository.GetById(request.RoadId);
            if (road == null)
                return Failed(nameof(request.RoadId), $"Invalid RoadId");

            var carRoadInDb = _carRoadRepository.Get(request.CarId, request.RoadId);
            if (carRoadInDb != null)
                return Failed(nameof(request.CarId), $"the car is already registered");

            var carRoad = new CarRoad
            {
                CarId = car.Id,
                RoadId = road.Id,
                PassCost = Convert.ToDecimal(_config["AppSettings:HighwayPassCost"]), 
                Card = new Card 
                {
                    Balance = Convert.ToDecimal(_config["AppSettings:HighwayWelcomeCredit"]),
                }
            };

            _carRoadRepository.Add(carRoad);
            await _unitOfWork.CommitAsync();

            return Succeeded(new RegisterRoadResponse { CarId = carRoad.CardId });
        }

        public async Task<ServiceResult> PassRoad(PassRoadRequest request)
        {
            var car = _carRepository.GetById(request.CarId);
            if (car == null)
                return Failed(nameof(request.CarId), $"Invalid CarId");

            var road = _roadRepository.GetById(request.RoadId);
            if (road == null)
                return Failed(nameof(request.RoadId), $"Invalid RoadId");

            var carRoad = _carRoadRepository.Get(request.CarId, request.RoadId);
            if (carRoad == null)
                return Failed(nameof(request.CarId), $"the car is not registered with road");

            var passCost = carRoad.PassCost;
            if (carRoad.Logs.Any())
            {
                var lastLog = carRoad.Logs.OrderBy(x => x.PassTime).Last();
                if ((DateTime.UtcNow - lastLog.PassTime).TotalMinutes < Convert.ToInt32(_config["AppSettings:FreePassMinutes"]))
                    passCost = 0;
            }

            if (carRoad.Card.Balance < passCost)
                return Failed(nameof(request.CarId), $"insufficient balance ");

            carRoad.Card.Balance -= passCost;
            carRoad.Logs.Add(new CarRoadLog {PassTime = DateTime.UtcNow , Cost = passCost });

            await _unitOfWork.CommitAsync();

            return Succeeded();
        }
    }
}
