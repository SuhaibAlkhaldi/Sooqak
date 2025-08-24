using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.DTO.ApartmentDetailsDTO.Input;
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


        [HttpPost("[action]")]
        public async Task<IActionResult> GetApartmentsByFilter([FromBody] ApartmentFilterDTO filter)
        {
            try
            {
                var result = await _apartment.GetApartmentsByFilter(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        
    }
}
