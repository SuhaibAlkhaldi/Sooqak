using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.Interface;

namespace Sooqak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartment _apartment;
        public ApartmentController(IApartment apartment)
        {
            _apartment = apartment;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetApartmentByRoomsCount(int roomsCount)
        {
            try
            {
                var result = await _apartment.GetApartmentByRoomsCount(roomsCount);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetApartmentByFloorNumber(int floorNumber)
        {
            try
            {
                var result = await _apartment.GetApartmentByFloorNumber(floorNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetApartmentByArea(double area)
        {
            try
            {
                var result = await _apartment.GetApartmentByArea(area);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetApartmentByLocation(string location)
        {
            try
            {
                var result = await _apartment.GetApartmentByLocation(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetApartmentByPrice(decimal price)
        {
            try
            {
                var result = await _apartment.GetApartmentByPrice(price);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
