using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
using Sooqak.DTO.ApartmentDetailsDTO.Output;
using Sooqak.DTO.WorksDTO.Input;
using Sooqak.DTO.WorksDTO.Output;
using Sooqak.Helper.Enums.Work;
using Sooqak.Interface;
using System.IO;

namespace Sooqak.Services
{
    public class WorkService : IWork
    {
        private readonly SooqakDbContext _context;
        public WorkService(SooqakDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetWorksOutputDTO>> GetWorksByFilter(WorkFilterDTO filter)
        {
            var query = _context.works.Include(w => w.Advertisement).AsQueryable();

            if (filter.ServiceType.HasValue)
                query = query.Where(w => w.ServiceType == filter.ServiceType.Value).OrderBy(s => s.ServiceType);

            if (filter.PriceType.HasValue)
                query = query.Where(w => w.PriceType == filter.PriceType.Value).OrderBy(p => p.PriceType);

            if (filter.MinBasePrice.HasValue)
                query = query.Where(w => w.BasePrice >= filter.MinBasePrice.Value).OrderBy(b => b.BasePrice);

            if (filter.MaxBasePrice.HasValue)
                query = query.Where(w => w.BasePrice <= filter.MaxBasePrice.Value).OrderBy(b => b.BasePrice);

            if (!string.IsNullOrEmpty(filter.Experience))
                query = query.Where(w => w.Experience.Contains(filter.Experience)).OrderBy(e => e.Experience);

            if (filter.Availability.HasValue)
                query = query.Where(w => w.Availability == filter.Availability.Value).OrderBy(a => a.Availability);

            if (!string.IsNullOrEmpty(filter.Location))
                query = query.Where(w => w.Advertisement.Location.Contains(filter.Location));


            query = query
                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                        .Take(filter.PageSize);

            return await query.Select(w => new GetWorksOutputDTO
            {
                WorksId = w.Id,
                Name = w.Name,
                ServiceType = w.ServiceType,
                PriceType = w.PriceType,
                BasePrice = w.BasePrice.Value,
                Experience = w.Experience,
                Availability = w.Availability,
                Price = w.Advertisement.Price,
                Location = w.Advertisement.Location,
                Image = w.Advertisement.Image
            }).ToListAsync();
        }

    }
}
