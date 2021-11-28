using Microsoft.AspNetCore.Mvc;
using Services.Contracts.Dtos;
using Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carService.GetAll();
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddCarResponse), 200)]
        public async Task<IActionResult> Add(AddCarRequest request)
        {
            var result = await _carService.Add(request);
            if(result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("{carId}")]
        public async Task<IActionResult> Edit(int carId, EditCarRequest request)
        {
            var result = await _carService.Edit(carId, request);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }


        [HttpDelete("{carId}")]
        public async Task<IActionResult> Delete(int carId)
        {
            var result = await _carService.Delete(carId);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("RegisterRoad")]
        [ProducesResponseType(typeof(RegisterRoadResponse), 200)]
        public async Task<IActionResult> RegisterRoad(RegisterRoadRequest request)
        {
            var result = await _carService.RegisterRoad(request);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("PassRoad")]
        public async Task<IActionResult> PassRoad(PassRoadRequest request)
        {
            var result = await _carService.PassRoad(request);
            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
