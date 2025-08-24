using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sooqak.DTO.UserFavorite.Input;
using Sooqak.Interface;

namespace Sooqak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoriteController : ControllerBase
    {
        private readonly IUserFavorite _userFavorite;

        public UserFavoriteController(IUserFavorite userFavorite)
        {
            _userFavorite = userFavorite;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserFavorites(int userId)
        {
            try
            {
                var result = await _userFavorite.GetUserFavorites(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddToFavorite(AddFavoriteDTO input)
        {
            try
            {
                var result = await _userFavorite.AddToFavorite(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveFromFavorite(AddFavoriteDTO input)
        {
            try
            {
                var result = await _userFavorite.RemoveFromFavorite(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
