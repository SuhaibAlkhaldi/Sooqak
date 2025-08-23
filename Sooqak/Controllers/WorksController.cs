using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.Helper.Enums.Work;
using Sooqak.Interface;

namespace Sooqak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly IWork _work;

        public WorksController(IWork work)
        {
            _work = work;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkByService(ServiceType service)
        {
            try
            {
                var result = await _work.GetWorkByService(service);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkByPriceType(PriceType priceType)
        {
            try
            {
                var result = await _work.GetWorkByPriceType(priceType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkByBasePrice(decimal basePrice)
        {
            try
            {
                var result = await _work.GetWorkByBasePrice(basePrice);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkByExperience(string experience)
        {
            try
            {
                var result = await _work.GetWorkByExperience(experience);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkByAvailability(bool isAvailable)
        {
            try
            {
                var result = await _work.GetWorkByAvailability(isAvailable);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkByLocation(string location)
        {
            try
            {
                var result = await _work.GetWorkByLocation(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
