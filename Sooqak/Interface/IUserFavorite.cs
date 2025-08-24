using Sooqak.DTO.UserFavorite.Input;
using Sooqak.DTO.UserFavorite.Output;

namespace Sooqak.Interface
{
    public interface IUserFavorite
    {
        Task<string> AddToFavorite(AddFavoriteDTO input);
        Task<string> RemoveFromFavorite(AddFavoriteDTO input);
        Task<List<FavoriteOutputDTO>> GetUserFavorites(int userId);
    }
}
