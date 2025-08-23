using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
using Sooqak.DTO.ApartmentDetailsDTO.Output;
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

        public async Task<List<GetWorksOutputDTO>> GetWorkByAvailability(bool isAvailable)
        {
            try
            {
                var getAvailability = await _context.works.Where(x => x.Availability == isAvailable)
                    .Select(a => new GetWorksOutputDTO
                    {
                        WorksId = a.Id,
                        Name = a.Name,
                        BasePrice = a.BasePrice.Value,
                        Experience = a.Experience,
                        PriceType = a.PriceType,
                        ServiceType = a.ServiceType,
                        Availability = a.Availability,
                        AdvertisementId = a.AdvertisementId
                    }).ToListAsync();
                return getAvailability;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetWorksOutputDTO>> GetWorkByBasePrice(decimal basePrice)
        {
            try
            {
                var getAvailability = await _context.works.Where(x => x.BasePrice == basePrice)
                    .Select(a => new GetWorksOutputDTO
                    {
                        WorksId = a.Id,
                        Name = a.Name,
                        BasePrice = a.BasePrice.Value,
                        Experience = a.Experience,
                        PriceType = a.PriceType,
                        ServiceType = a.ServiceType,
                        Availability = a.Availability,
                        AdvertisementId = a.AdvertisementId
                    }).ToListAsync();
                return getAvailability;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<GetWorksOutputDTO>> GetWorkByExperience(string experience)
        {
            try
            {
                var getAvailability = await _context.works.Where(x => x.Experience == experience)
                    .Select(a => new GetWorksOutputDTO
                    {
                        WorksId = a.Id,
                        Name = a.Name,
                        BasePrice = a.BasePrice.Value,
                        Experience = a.Experience,
                        PriceType = a.PriceType,
                        ServiceType = a.ServiceType,
                        Availability = a.Availability,
                        AdvertisementId = a.AdvertisementId
                    }).ToListAsync();
                return getAvailability;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<List<GetWorksOutputDTO>> GetWorkByPriceType(PriceType priceType)
        {
            try
            {
                var getAvailability = await _context.works.Where(x => x.PriceType == priceType)
                    .Select(a => new GetWorksOutputDTO
                    {
                        WorksId = a.Id,
                        Name = a.Name,
                        BasePrice = a.BasePrice.Value,
                        Experience = a.Experience,
                        PriceType = a.PriceType,
                        ServiceType = a.ServiceType,
                        Availability = a.Availability,
                        AdvertisementId = a.AdvertisementId
                    }).ToListAsync();
                return getAvailability;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetWorksOutputDTO>> GetWorkByService(ServiceType service)
        {
            try
            {
                var getAvailability = await _context.works.Where(x => x.ServiceType == service)
                    .Select(a => new GetWorksOutputDTO
                    {
                        WorksId = a.Id,
                        Name = a.Name,
                        BasePrice = a.BasePrice.Value,
                        Experience = a.Experience,
                        PriceType = a.PriceType,
                        ServiceType = a.ServiceType,
                        Availability = a.Availability,
                        AdvertisementId = a.AdvertisementId
                    }).ToListAsync();
                return getAvailability;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public async Task<List<GetWorkByLocationDTO>> GetWorkByLocation(string location)
        {
            try
            {
                var getLocation = await _context.advertisements.Where(x => x.Location == location).SingleOrDefaultAsync();
                if (getLocation == null)
                {
                    throw new Exception($"Could not find location {location}");
                }
                var apartment = await (from work in _context.works
                                       join adv in _context.advertisements on work.AdvertisementId equals adv.Id
                                       where adv.Location == location
                                       select new GetWorkByLocationDTO
                                       {
                                           WorksId = work.Id,
                                           Name = work.Name,
                                           BasePrice = work.BasePrice.Value,
                                           Experience = work.Experience,
                                           PriceType = work.PriceType,
                                           ServiceType = work.ServiceType,
                                           Availability = work.Availability,
                                           AdvertisementId = work.AdvertisementId,
                                           Location = adv.Location,
                                       }).ToListAsync();
                return apartment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
