using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.DTO.ElectricalDeviceDTO.Input;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> GetElectricalAppliancesByFilter([FromBody] ElectricalApplianceFilterDTO filter)
        {
            try
            {
                var result = await _electricalAppliance.GetElectricalAppliancesByFilter(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


       
    }
}
