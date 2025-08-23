using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.Helper.Enums.CarDetailsEnum;
using Sooqak.Interface;

namespace Sooqak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICar _car;
        public CarsController(ICar car)
        {
            _car = car;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsByModel(string model)
        {
            try
            {
                var result = await _car.GetCarsByModel(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsByYears(int year)
        {
            try
            {
                var result = await _car.GetCarsByYears(year);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsBySeatsCount(int seatCount)
        {
            try
            {
                var result = await _car.GetCarsBySeatsCount(seatCount);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsByFuelType(EFuelType fuelType)
        {
            try
            {
                var result = await _car.GetCarsByFuelType(fuelType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsByTransmission(ETransmission transmission)
        {
            try
            {
                var result = await _car.GetCarsByTransmission(transmission);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsByPrice(decimal price)
        {
            try
            {
                var result = await _car.GetCarsByPrice(price);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsByLocation(string location)
        {
            try
            {
                var result = await _car.GetCarsByLocation(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
