using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.Interface;

namespace Sooqak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricalApplianceController : ControllerBase
    {
        private readonly IElectricalAppliance _electricalAppliance;

        public ElectricalApplianceController(IElectricalAppliance electricalAppliance)
        {
            _electricalAppliance = electricalAppliance;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetElectricalApplianceByBrand(string brand)
        {
            try
            {
                var result = await _electricalAppliance.GetElectricalApplianceByBrand(brand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetElectricalApplianceByModel(string model)
        {
            try
            {
                var result = await _electricalAppliance.GetElectricalApplianceByModel(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetElectricalApplianceByLocation(string location)
        {
            try
            {
                var result = await _electricalAppliance.GetElectricalApplianceByLocation(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetElectricalApplianceByPrice(decimal price)
        {
            try
            {
                var result = await _electricalAppliance.GetElectricalApplianceByPrice(price);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
