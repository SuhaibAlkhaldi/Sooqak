using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
using Sooqak.DTO.ApartmentDetailsDTO.Output;
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

        public async Task<List<GetElectricalDeviceOutputDTO>> GetElectricalApplianceByBrand(string brand)
        {
            try
            {
                var getElectricalAppliance = await _context.electricalAppliances.Where(x => x.Brand == brand)
                    .Select(e => new GetElectricalDeviceOutputDTO 
                        {
                            ElectricalDeviceId = e.Id,
                            Brand = e.Brand,
                            Model = e.Model,
                            Condition = e.Condition,
                            Feature = e.Feature,
                            IsWarranty = e.IsWarranty,
                            AdvertisementId = e.AdvertisementId
                        }).ToListAsync();
                return getElectricalAppliance;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<List<GetElectricalDeviceOutputDTO>> GetElectricalApplianceByModel(string model)
        {
            try
            {
                var getElectricalAppliance = await _context.electricalAppliances.Where(x => x.Model == model)
                    .Select(e => new GetElectricalDeviceOutputDTO
                    {
                        ElectricalDeviceId = e.Id,
                        Brand = e.Brand,
                        Model = e.Model,
                        Condition = e.Condition,
                        Feature = e.Feature,
                        IsWarranty = e.IsWarranty,
                        AdvertisementId = e.AdvertisementId
                    }).ToListAsync();
                return getElectricalAppliance;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<List<GetElectricalApplianceByLocationDTO>> GetElectricalApplianceByLocation(string location)
        {
            try
            {
                var getLocation = await _context.advertisements.Where(x => x.Location == location).SingleOrDefaultAsync();
                if (getLocation == null)
                {
                    throw new Exception($"Could not find location {location}");
                }
                var electricalDevice = await (from elec in _context.electricalAppliances
                                       join adv in _context.advertisements on elec.AdvertisementId equals adv.Id
                                       where adv.Location == location
                                       select new GetElectricalApplianceByLocationDTO
                                       {
                                          ElectricalDeviceId = elec.Id,
                                          Brand = elec.Brand,
                                          Model = elec.Model,
                                          Condition = elec.Condition,
                                          Feature = elec.Feature,
                                          IsWarranty = elec.IsWarranty,
                                          AdvertisementId = elec.AdvertisementId,
                                          Location = adv.Location,
                                       }).ToListAsync();
                return electricalDevice;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<GetElectricalApplianceByPriceDTO>> GetElectricalApplianceByPrice(decimal price)
        {
            try
            {
                var electricalDevice = await (from elec in _context.electricalAppliances
                                       join adv in _context.advertisements on elec.AdvertisementId equals adv.Id
                                       where adv.Price == price
                                       select new GetElectricalApplianceByPriceDTO
                                       {
                                           ElectricalDeviceId = elec.Id,
                                           Brand = elec.Brand,
                                           Model = elec.Model,
                                           Condition = elec.Condition,
                                           Feature = elec.Feature,
                                           IsWarranty = elec.IsWarranty,
                                           AdvertisementId = elec.AdvertisementId,
                                           Price = adv.Price
                                       }).ToListAsync();
                return electricalDevice;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
