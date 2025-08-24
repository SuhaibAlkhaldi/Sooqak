using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
using Sooqak.DTO.ApartmentDetailsDTO.Output;
using Sooqak.DTO.ElectricalDeviceDTO.Input;
using Sooqak.DTO.ElectricalDeviceDTO.Output;
using Sooqak.Interface;

namespace Sooqak.Services
{
    public class ElectricalApplianceService : IElectricalAppliance
    {
        private readonly SooqakDbContext _context;
        public ElectricalApplianceService(SooqakDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetElectricalDeviceOutputDTO>> GetElectricalAppliancesByFilter(ElectricalApplianceFilterDTO filter)
        {
            var query = _context.electricalAppliances.Include(e => e.Advertisement).AsQueryable();

            if (!string.IsNullOrEmpty(filter.Brand))
                query = query.Where(e => e.Brand.Contains(filter.Brand)).OrderBy(b => b.Brand);

            if (!string.IsNullOrEmpty(filter.Model))
                query = query.Where(e => e.Model.Contains(filter.Model)).OrderBy(m => m.Model);

            if (filter.MinPrice.HasValue)
                query = query.Where(e => e.Advertisement.Price >= filter.MinPrice.Value).OrderBy(p => p.Advertisement.Price);

            if (filter.MaxPrice.HasValue)
                query = query.Where(e => e.Advertisement.Price <= filter.MaxPrice.Value).OrderBy(p => p.Advertisement.Price);

            if (!string.IsNullOrEmpty(filter.Location))
                query = query.Where(e => e.Advertisement.Location.Contains(filter.Location));


            query = query
                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                        .Take(filter.PageSize);

            return await query.Select(e => new GetElectricalDeviceOutputDTO
            {
                ElectricalDeviceId = e.Id,
                Brand = e.Brand,
                Model = e.Model,
                Condition = e.Condition,
                IsWarranty = e.IsWarranty,
                Feature = e.Feature,
                Price = e.Advertisement.Price,
                Location = e.Advertisement.Location,
                Image = e.Advertisement.Image
            }).ToListAsync();
        }

        
    }
}
