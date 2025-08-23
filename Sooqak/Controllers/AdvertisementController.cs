using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.DTO.AdvertisementDTO.Input;
using Sooqak.Interface;

namespace Sooqak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisement _advertisement;

        public AdvertisementController(IAdvertisement advertisement)
        {
            _advertisement = advertisement;
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetAdvertisementById(int advertisementId)
        {
            try
            {
                var result = await _advertisement.GetAdvertisementById(advertisementId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAdvertisement()
        {
            try
            {
                var result = await _advertisement.GetAllAdvertisements();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddAdvertisement(AddAdvertisementInputDTO input)
        {
            try
            {
                var result = await _advertisement.AddAdvertisement(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAdvertisement(UpdateAdvertisementInputDTO input)
        {
            try
            {
                var result = await _advertisement.UpdateAdvertisement(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteAdvertisement(int advertisementId)
        {
            try
            {
                var result = await _advertisement.DeleteAdvertisement(advertisementId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
