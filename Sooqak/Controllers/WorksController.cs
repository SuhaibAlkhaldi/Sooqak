using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.DTO.WorksDTO.Input;
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


        [HttpPost("[action]")]
        public async Task<IActionResult> GetWorksByFilter([FromBody] WorkFilterDTO filter)
        {
            try
            {
                var result = await _work.GetWorksByFilter(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        
    }
}
