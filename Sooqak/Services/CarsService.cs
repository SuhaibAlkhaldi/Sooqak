using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Sooqak.Context;
using Sooqak.DTO.ApartmentDetailsDTO.Output;
using Sooqak.DTO.CarDetailsDTO.Input;
using Sooqak.DTO.CarDetailsDTO.Output;
using Sooqak.Helper.Enums.CarDetailsEnum;
using Sooqak.Interface;

namespace Sooqak.Services
{
    public class CarsService : ICar
    {
        private readonly SooqakDbContext _context;
        public CarsService(SooqakDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetCarDetailsOutputDTO>> GetCarsByFilter(CarFilterDTO filter)
        {
            var query = _context.carDetails
        .Include(c => c.Advertisement)
        .AsQueryable();

            if (!string.IsNullOrEmpty(filter.Model))
                query = query.Where(c => c.Model.Contains(filter.Model)).OrderBy(m => m.Model);

            if (filter.Year.HasValue)
                query = query.Where(c => c.Year == filter.Year.Value).OrderBy(y => y.Year);

            if (filter.SeatsCount.HasValue)
                query = query.Where(c => c.SeatsCount == filter.SeatsCount.Value);

            if (filter.FuelType.HasValue)
                query = query.Where(c => c.FuelType == filter.FuelType.Value);

            if (filter.Transmission.HasValue)
                query = query.Where(c => c.Transmission == filter.Transmission.Value);

            if (filter.MinPrice.HasValue)
                query = query.Where(c => c.Advertisement.Price >= filter.MinPrice.Value).OrderBy(p => p.Advertisement.Price);

            if (filter.MaxPrice.HasValue)
                query = query.Where(c => c.Advertisement.Price <= filter.MaxPrice.Value).OrderBy(p => p.Advertisement.Price);

            if (!string.IsNullOrEmpty(filter.Location))
                query = query.Where(c => c.Advertisement.Location.Contains(filter.Location));

            query = query
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize);

            var result = await query.Select(c => new GetCarDetailsOutputDTO
            {
                CarDetailsId = c.Id,
                Model = c.Model,
                Year = c.Year,
                SeatsCount = c.SeatsCount,
                FuelType = c.FuelType,
                Transmission = c.Transmission,
                Price = c.Advertisement.Price,
                Location = c.Advertisement.Location,
                Image = c.Advertisement.Image
            }).ToListAsync();

            return result;
        }



        
    }
}
