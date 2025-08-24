using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
using Sooqak.DTO.ApartmentDetailsDTO.Input;
using Sooqak.DTO.ApartmentDetailsDTO.Output;
using Sooqak.Interface;

namespace Sooqak.Services
{
    public class ApartmentService : IApartment
    {
        private readonly SooqakDbContext _context;
        public ApartmentService(SooqakDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetApartmentOutputDTO>> GetApartmentsByFilter(ApartmentFilterDTO filter)
        {
            var query = _context.apartmentDetails.Include(a => a.Advertisement).AsQueryable();

            if (filter.RoomsCount.HasValue)
                query = query.Where(a => a.RoomsCount == filter.RoomsCount.Value).OrderBy(r => r.RoomsCount);

            if (filter.FloorNumber.HasValue)
                query = query.Where(a => a.FloorNumber == filter.FloorNumber.Value);

            if (filter.MinArea.HasValue)
                query = query.Where(a => a.Area >= filter.MinArea.Value).OrderBy(a => a.Area);

            if (filter.MaxArea.HasValue)
                query = query.Where(a => a.Area <= filter.MaxArea.Value).OrderBy(a => a.Area);

            if (filter.MinPrice.HasValue)
                query = query.Where(a => a.Advertisement.Price >= filter.MinPrice.Value).OrderBy(p => p.Advertisement.Price);

            if (filter.MaxPrice.HasValue)
                query = query.Where(a => a.Advertisement.Price <= filter.MaxPrice.Value).OrderBy(p => p.Advertisement.Price);

            if (!string.IsNullOrEmpty(filter.Location))
                query = query.Where(a => a.Advertisement.Location.Contains(filter.Location));


            query = query
                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                        .Take(filter.PageSize);

            return await query.Select(a => new GetApartmentOutputDTO
            {
                ApartmentId = a.Id,
                RoomsCount = a.RoomsCount,
                BathroomsCount = a.BathroomsCount,
                FloorNumber = a.FloorNumber,
                TotalFloor = a.TotalFloor,
                Area = a.Area,
                IsFurnished = a.IsFurnished,
                IsHaveBalcony = a.IsHaveBalcony,
                IsHaveElevator = a.IsHaveElevator,
                IsHaveParking = a.IsHaveParking,
                Image = a.Advertisement.Image,
                Description = a.Description,
                Price = a.Advertisement.Price,
                Location = a.Advertisement.Location,
            }).ToListAsync();
        }
    }
}
