using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Sooqak.Context;
using Sooqak.DTO.ApartmentDetailsDTO.Output;
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

        

        public async Task<List<GetCarDetailsOutputDTO>> GetCarsByModel(string model)
        {
            try
            {
                var car = await _context.carDetails.Where(x => x.Model == model)
                    .Select(c => new GetCarDetailsOutputDTO
                    {
                        CarDetailsId = c.Id,
                        Model = c.Model,
                        Color = c.Color,
                        FuelType = c.FuelType,
                        Image = c.Image,
                        Mileage = c.Mileage,
                        SeatsCount = c.SeatsCount,
                        Transmission = c.Transmission,
                        Year = c.Year,
                        AdvertisementId = c.AdvertisementId
                    }).ToListAsync();
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<List<GetCarDetailsOutputDTO>> GetCarsByYears(int year)
        {
            try
            {
                var car = await _context.carDetails.Where(x => x.Year == year)
                    .Select(c => new GetCarDetailsOutputDTO
                    {
                        CarDetailsId = c.Id,
                        Model = c.Model,
                        Color = c.Color,
                        FuelType = c.FuelType,
                        Image = c.Image,
                        Mileage = c.Mileage,
                        SeatsCount = c.SeatsCount,
                        Transmission = c.Transmission,
                        Year = c.Year,
                        AdvertisementId = c.AdvertisementId
                    }).ToListAsync();
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<GetCarDetailsOutputDTO>> GetCarsByFuelType(EFuelType fuelType)
        {
            try
            {
                var car = await _context.carDetails.Where(x => x.FuelType == fuelType)
                    .Select(c => new GetCarDetailsOutputDTO
                    {
                        CarDetailsId = c.Id,
                        Model = c.Model,
                        Color = c.Color,
                        FuelType = c.FuelType,
                        Image = c.Image,
                        Mileage = c.Mileage,
                        SeatsCount = c.SeatsCount,
                        Transmission = c.Transmission,
                        Year = c.Year,
                        AdvertisementId = c.AdvertisementId
                    }).ToListAsync();
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetCarByLocationDTO>> GetCarsByLocation(string location)
        {
            try
            {
                var getLocation = await _context.advertisements.Where(x => x.Location == location).SingleOrDefaultAsync();
                if (getLocation == null)
                {
                    throw new Exception($"Could not find location {location}");
                }
                var car = await (from c in _context.carDetails
                                 join adv in _context.advertisements on c.AdvertisementId equals adv.Id
                                 where adv.Location == location
                                 select new GetCarByLocationDTO
                                 {
                                     CarDetailsId = c.Id,
                                     Model = c.Model,
                                     Color = c.Color,
                                     FuelType = c.FuelType,
                                     Image = c.Image,
                                     Mileage = c.Mileage,
                                     SeatsCount = c.SeatsCount,
                                     Transmission = c.Transmission,
                                     Year = c.Year,
                                     AdvertisementId = c.AdvertisementId,
                                     Location = adv.Location,
                                 }).ToListAsync();
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }




        public async Task<List<GetCarByPriceDTO>> GetCarsByPrice(decimal price)
        {
            try
            {
                var getLocation = await _context.advertisements.Where(x => x.Price == price).SingleOrDefaultAsync();
                if (getLocation == null)
                {
                    throw new Exception($"Invalid Price {price}");
                }
                var car = await (from c in _context.carDetails
                                 join adv in _context.advertisements on c.AdvertisementId equals adv.Id
                                 where adv.Price == price
                                 select new GetCarByPriceDTO
                                 {
                                     CarDetailsId = c.Id,
                                     Model = c.Model,
                                     Color = c.Color,
                                     FuelType = c.FuelType,
                                     Image = c.Image,
                                     Mileage = c.Mileage,
                                     SeatsCount = c.SeatsCount,
                                     Transmission = c.Transmission,
                                     Year = c.Year,
                                     AdvertisementId = c.AdvertisementId,
                                     Price = adv.Price,
                                 }).ToListAsync();
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetCarDetailsOutputDTO>> GetCarsBySeatsCount(int seatCount)
        {
            try
            {
                var car = await _context.carDetails.Where(x => x.SeatsCount == seatCount)
                    .Select(c => new GetCarDetailsOutputDTO
                    {
                        CarDetailsId = c.Id,
                        Model = c.Model,
                        Color = c.Color,
                        FuelType = c.FuelType,
                        Image = c.Image,
                        Mileage = c.Mileage,
                        SeatsCount = c.SeatsCount,
                        Transmission = c.Transmission,
                        Year = c.Year,
                        AdvertisementId = c.AdvertisementId
                    }).ToListAsync();
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetCarDetailsOutputDTO>> GetCarsByTransmission(ETransmission transmission)
        {
            try
            {
                var car = await _context.carDetails.Where(x => x.Transmission == transmission)
                    .Select(c => new GetCarDetailsOutputDTO
                    {
                        CarDetailsId = c.Id,
                        Model = c.Model,
                        Color = c.Color,
                        FuelType = c.FuelType,
                        Image = c.Image,
                        Mileage = c.Mileage,
                        SeatsCount = c.SeatsCount,
                        Transmission = c.Transmission,
                        Year = c.Year,
                        AdvertisementId = c.AdvertisementId
                    }).ToListAsync();
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
