using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.DTO.CategoryDTO.Input;
using Sooqak.Interface;

namespace Sooqak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var result = await _category.GetCategoryById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var result = await _category.GetAllCategories();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory(AddCategoryInputDTO input)
        {
            try
            {
                var result = await _category.AddCategory(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("[action]")]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryInputDTO input)
        {
            try
            {
                var result = await _category.UpdateCategory(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var result = await _category.DeleteCategory(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
