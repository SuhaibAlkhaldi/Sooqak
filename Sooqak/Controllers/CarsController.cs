using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.DTO.CarDetailsDTO.Input;
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


        [HttpPost("[action]")]
        public async Task<IActionResult> GetCarsByFilter([FromBody] CarFilterDTO filter)
        {
            try
            {
                var result = await _car.GetCarsByFilter(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        
    }
}
