using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
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

        public async Task<List<GetApartmentOutputDTO>> GetApartmentByArea(double area)
        {
            try
            {
                var apartment = await _context.apartmentDetails.Where(x => x.Area == area)
                    .Select(c => new GetApartmentOutputDTO
                    {
                        ApartmentId = c.Id,
                        Area = c.Area,
                        BathroomsCount = c.BathroomsCount,
                        Description = c.Description,
                        FloorNumber = c.FloorNumber,
                        Image = c.Image,
                        IsFurnished = c.IsFurnished,
                        IsHaveBalcony = c.IsHaveBalcony,
                        IsHaveElevator = c.IsHaveElevator,
                        IsHaveParking = c.IsHaveParking,
                        RoomsCount = c.RoomsCount,
                        TotalFloor = c.TotalFloor,
                        AdvertisementId = c.AdvertisementId
                    }).ToListAsync();
                return apartment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetApartmentOutputDTO>> GetApartmentByFloorNumber(int floorNumber)
        {
            try
            {
                var apartment = await _context.apartmentDetails.Where(x => x.FloorNumber == floorNumber)
                    .Select(c => new GetApartmentOutputDTO
                    {
                        ApartmentId = c.Id,
                        Area = c.Area,
                        BathroomsCount = c.BathroomsCount,
                        Description = c.Description,
                        FloorNumber = c.FloorNumber,
                        Image = c.Image,
                        IsFurnished = c.IsFurnished,
                        IsHaveBalcony = c.IsHaveBalcony,
                        IsHaveElevator = c.IsHaveElevator,
                        IsHaveParking = c.IsHaveParking,
                        RoomsCount = c.RoomsCount,
                        TotalFloor = c.TotalFloor,
                        AdvertisementId = c.AdvertisementId
                    }).ToListAsync();
                return apartment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetApartmentByLocationDTO>> GetApartmentByLocation(string location)
        {
            try
            {
                var getLocation = await _context.advertisements.Where(x => x.Location == location).SingleOrDefaultAsync();
                if (getLocation == null)
                {
                    throw new Exception($"Could not find location {location}");
                }
                var apartment = await( from apart in _context.apartmentDetails
                                join adv in _context.advertisements on apart.AdvertisementId equals adv.Id
                                where adv.Location == location
                                select new GetApartmentByLocationDTO
                                {
                                    ApartmentId = apart.Id,
                                    Area = apart.Area,
                                    BathroomsCount = apart.BathroomsCount,
                                    Description = apart.Description,
                                    FloorNumber = apart.FloorNumber,
                                    Image = apart.Image,
                                    IsFurnished = apart.IsFurnished,
                                    IsHaveBalcony = apart.IsHaveBalcony,
                                    IsHaveElevator = apart.IsHaveElevator,
                                    IsHaveParking = apart.IsHaveParking,
                                    RoomsCount = apart.RoomsCount,
                                    TotalFloor = apart.TotalFloor,
                                    AdvertisementId = apart.AdvertisementId,
                                    Location = adv.Location,
                                }).ToListAsync();
                return apartment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<List<GetApartmentOutputDTO>> GetApartmentByRoomsCount(int roomsCount)
        {
            try
            {
                var apartment = await _context.apartmentDetails.Where(x => x.RoomsCount == roomsCount)
                    .Select(c => new GetApartmentOutputDTO
                    {
                        ApartmentId = c.Id,
                        Area = c.Area,
                        BathroomsCount = c.BathroomsCount,
                        Description = c.Description,
                        FloorNumber = c.FloorNumber,
                        Image = c.Image,
                        IsFurnished = c.IsFurnished,
                        IsHaveBalcony = c.IsHaveBalcony,
                        IsHaveElevator = c.IsHaveElevator,
                        IsHaveParking = c.IsHaveParking,
                        RoomsCount = c.RoomsCount,
                        TotalFloor = c.TotalFloor,
                        AdvertisementId = c.AdvertisementId
                    }).ToListAsync();
                return apartment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<List<GetApartmentByPriceDTO>> GetApartmentByPrice(decimal price)
        {
            try
            {
                var apartment = await (from apart in _context.apartmentDetails
                                       join adv in _context.advertisements on apart.AdvertisementId equals adv.Id
                                       where adv.Price == price
                                       select new GetApartmentByPriceDTO
                                       {
                                           ApartmentId = apart.Id,
                                           Area = apart.Area,
                                           BathroomsCount = apart.BathroomsCount,
                                           Description = apart.Description,
                                           FloorNumber = apart.FloorNumber,
                                           Image = apart.Image,
                                           IsFurnished = apart.IsFurnished,
                                           IsHaveBalcony = apart.IsHaveBalcony,
                                           IsHaveElevator = apart.IsHaveElevator,
                                           IsHaveParking = apart.IsHaveParking,
                                           RoomsCount = apart.RoomsCount,
                                           TotalFloor = apart.TotalFloor,
                                           AdvertisementId = apart.AdvertisementId,
                                           Price = adv.Price
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
