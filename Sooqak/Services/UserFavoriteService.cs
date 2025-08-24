using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
using Sooqak.DTO.UserFavorite.Input;
using Sooqak.DTO.UserFavorite.Output;
using Sooqak.Entities;
using Sooqak.Interface;

namespace Sooqak.Services
{
    public class UserFavoriteService : IUserFavorite
    {
        private readonly SooqakDbContext _context;
        public UserFavoriteService(SooqakDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddToFavorite(AddFavoriteDTO input)
        {
            try
            {
                var exists = await _context.userFavorite
                    .AnyAsync(f => f.UserId == input.UserId && f.AdvertisementId == input.AdvertisementId);
                if (exists)
                    return "Advertisement already in favorites";

                var favorite = new UserFavorite
                {
                    UserId = input.UserId,
                    AdvertisementId = input.AdvertisementId,
                    CreationDate = DateTime.Now,
                    CreatedBy = "System"
                };

                await _context.userFavorite.AddAsync(favorite);
                await _context.SaveChangesAsync();
                return "Added to favorites successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public async Task<string> RemoveFromFavorite(AddFavoriteDTO input)
        {
            try
            {
                var favorite = await _context.userFavorite.Where(f => f.UserId == input.UserId &&
                                f.AdvertisementId == input.AdvertisementId).FirstOrDefaultAsync();

                if (favorite == null)
                    return "Favorite not found";

                _context.userFavorite.Remove(favorite);
                await _context.SaveChangesAsync();
                return "Removed from favorites successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public async Task<List<FavoriteOutputDTO>> GetUserFavorites(int userId)
        {
            try
            {
                var favorites = await _context.userFavorite.Where(f => f.UserId == userId)
                    .Select(f => new FavoriteOutputDTO
                    {
                        AdvertisementId = f.AdvertisementId,
                        Title = f.Advertisement.Title,
                        Price = f.Advertisement.Price,
                        Category = f.Advertisement.Category.CategoryType.ToString(),
                        Location = f.Advertisement.Location
                    }).ToListAsync();
                return favorites;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
