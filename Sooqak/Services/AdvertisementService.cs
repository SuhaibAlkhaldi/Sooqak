using Microsoft.EntityFrameworkCore;
using Sooqak.Context;
using Sooqak.DTO.AdvertisementDTO.Input;
using Sooqak.DTO.AdvertisementDTO.Output;
using Sooqak.DTO.ApartmentDetailsDTO.Output;
using Sooqak.DTO.CarDetailsDTO.Output;
using Sooqak.DTO.ElectricalDeviceDTO.Output;
using Sooqak.DTO.WorksDTO.Output;
using Sooqak.Entities;
using Sooqak.Helper.Enums.AdvertisementEnum;
using Sooqak.Helper.Enums.Category;
using Sooqak.Helper.Image;
using Sooqak.Interface;

namespace Sooqak.Services
{
    public class AdvertisementService : IAdvertisement
    {

        private readonly SooqakDbContext _context;
        public AdvertisementService(SooqakDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddAdvertisement(AddAdvertisementInputDTO input)
        {
            try
            {

                var category = _context.categories
                    .Where(c => c.Id == input.CategoryId)
                    .FirstOrDefault();

                if (category == null)
                    return "Category not found";


                var advertisement = new Advertisement
                {
                    Title = input.Title,
                    Description = input.Description,
                    Price = input.Price,
                    Status = input.Status,
                    AdvertisementType = input.AdvertisementType,
                    Location = input.Location,
                    Image = await ImageHelper.SaveImageAsync(input.Image),
                    CategoryId = input.CategoryId,
                    CreationDate = DateTime.Now,
                    CreatedBy = "System",
                    UserId = input.UserId
                };

                await _context.advertisements.AddAsync(advertisement);
                await _context.SaveChangesAsync(); 

               
                switch (category.CategoryType)
                {
                    case ECategoryType.Cars:
                        if (input.CarDetails == null)
                            return "Car details are required for Cars category";

                        var carDetails = new CarDetail
                        {
                            AdvertisementId = advertisement.Id,
                            SeatsCount = input.CarDetails.SeatsCount,
                            Model = input.CarDetails.Model,
                            Year = input.CarDetails.Year,
                            Mileage = input.CarDetails.Mileage,
                            Transmission = input.CarDetails.Transmission,
                            FuelType = input.CarDetails.FuelType,
                            Color = input.CarDetails.Color,
                            CreationDate = DateTime.Now,
                            CreatedBy = "System"
                        };
                        await _context.carDetails.AddAsync(carDetails);
                        break;

                    case ECategoryType.Apartment:
                        if (input.ApartmentDetails == null)
                            return "Apartment details are required for Apartments category";

                        var apartmentDetails = new ApartmentDetail
                        {
                            AdvertisementId = advertisement.Id,
                            TotalFloor = input.ApartmentDetails.TotalFloor,
                            Area = input.ApartmentDetails.Area,
                            RoomsCount = input.ApartmentDetails.RoomsCount,
                            BathroomsCount = input.ApartmentDetails.BathroomsCount,
                            FloorNumber = input.ApartmentDetails.FloorNumber,
                            IsHaveBalcony = input.ApartmentDetails.IsHaveBalcony,
                            IsHaveElevator = input.ApartmentDetails.IsHaveElevator,
                            IsFurnished = input.ApartmentDetails.IsFurnished,
                            IsHaveParking = input.ApartmentDetails.IsHaveParking,
                            Description = input.ApartmentDetails.Description,
                            
                            CreationDate = DateTime.Now,
                            CreatedBy = "System"
                        };
                        await _context.apartmentDetails.AddAsync(apartmentDetails);
                        break;

                    case ECategoryType.ElectricalDevice:
                        if (input.ElectricalDevice == null)
                            return "Electrical Device details are required for Electrical Device category";

                        var electricalDevice = new ElectricalAppliance
                        {
                            AdvertisementId = advertisement.Id,
                            Brand = input.ElectricalDevice.Brand,
                            Model = input.ElectricalDevice.Model,
                            Condition = input.ElectricalDevice.Condition,
                            IsWarranty = input.ElectricalDevice.IsWarranty,
                            Feature = input.ElectricalDevice.Feature,
                            CreationDate = DateTime.Now,
                            CreatedBy = "System"
                        };
                        await _context.electricalAppliances.AddAsync(electricalDevice);
                        break;

                    case ECategoryType.Works:
                        if (input.Works == null)
                            return "Works details are required for Works category";

                        var work = new Work
                        {
                            AdvertisementId = advertisement.Id,
                            Name = input.Works.Name,
                            ServiceType = input.Works.ServiceType,
                            PriceType = input.Works.PriceType,
                            BasePrice = input.Works.BasePrice,
                            Experience = input.Works.Experience,
                            Availability = input.Works.Availability,
                            CreationDate = DateTime.Now,
                            CreatedBy = "System"
                        };
                        await _context.works.AddAsync(work);
                        break;

                    default:
                        return "Unsupported category type for advertisement";
                }

                _context.SaveChanges(); 
                return "Advertisement created successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateAdvertisement(UpdateAdvertisementInputDTO input)
        {
            try
            {
                var advertisement = await _context.advertisements
                    .FirstOrDefaultAsync(a => a.Id == input.Id);

                if (advertisement == null)
                    return "Advertisement not found";


                if (!string.IsNullOrEmpty(input.Title))
                    advertisement.Title = input.Title;

                if (!string.IsNullOrEmpty(input.Description))
                    advertisement.Description = input.Description;

                if (input.Price.HasValue && input.Price.Value > 0)
                    advertisement.Price = input.Price.Value;

                if (!string.IsNullOrEmpty(input.Location))
                    advertisement.Location = input.Location;

                if (input.Status.HasValue)
                    advertisement.Status = input.Status.Value;
                
                 

                if (input.AdvertisementType.HasValue)
                    advertisement.AdvertisementType = input.AdvertisementType.Value;


                var category = await _context.categories
                    .FirstOrDefaultAsync(c => c.Id == advertisement.CategoryId);

                if (category == null)
                    return "Category not found";

                switch (category.CategoryType)
                {
                    case ECategoryType.Cars:
                        var carDetails = await _context.carDetails
                            .FirstOrDefaultAsync(c => c.AdvertisementId == advertisement.Id);

                        if (carDetails != null && input.CarDetails != null)
                        {
                            if (!string.IsNullOrEmpty(input.CarDetails.Model))
                                carDetails.Model = input.CarDetails.Model;

                            if (input.CarDetails.Year.HasValue && input.CarDetails.Year.Value > 0)
                            {
                                carDetails.Year = input.CarDetails.Year.Value;
                            }

                            if (input.CarDetails.SeatsCount.HasValue && input.CarDetails.SeatsCount.Value > 0)
                            {
                                carDetails.SeatsCount = input.CarDetails.SeatsCount.Value;
                            }

                            if (!string.IsNullOrEmpty(input.CarDetails.Mileage))
                                carDetails.Mileage = input.CarDetails.Mileage;

                            if (!string.IsNullOrEmpty(input.CarDetails.Color))
                                carDetails.Color = input.CarDetails.Color;


                            if (input.CarDetails.FuelType.HasValue)
                            {
                                carDetails.FuelType = input.CarDetails.FuelType.Value;
                            }
                            if (input.CarDetails.Transmission.HasValue)
                                carDetails.Transmission = input.CarDetails.Transmission.Value;
                        }
                        break;

                    case ECategoryType.Apartment:
                        var apartmentDetails = await _context.apartmentDetails
                            .FirstOrDefaultAsync(a => a.AdvertisementId == advertisement.Id);

                        if (apartmentDetails != null && input.ApartmentDetails != null)
                        {
                            if (input.ApartmentDetails.TotalFloor.HasValue)
                                apartmentDetails.TotalFloor = input.ApartmentDetails.TotalFloor.Value;

                            if (input.ApartmentDetails.Area.HasValue)
                                apartmentDetails.Area = input.ApartmentDetails.Area.Value;

                            if (input.ApartmentDetails.RoomsCount.HasValue)
                                apartmentDetails.RoomsCount = input.ApartmentDetails.RoomsCount.Value;

                            if (input.ApartmentDetails.BathroomsCount.HasValue)
                                apartmentDetails.BathroomsCount = input.ApartmentDetails.BathroomsCount.Value;

                            if (input.ApartmentDetails.FloorNumber.HasValue)
                                apartmentDetails.FloorNumber = input.ApartmentDetails.FloorNumber.Value;

                            if (input.ApartmentDetails.IsHaveBalcony.HasValue)
                                apartmentDetails.IsHaveBalcony = input.ApartmentDetails.IsHaveBalcony.Value;

                            if (input.ApartmentDetails.IsHaveElevator.HasValue)
                                apartmentDetails.IsHaveElevator = input.ApartmentDetails.IsHaveElevator.Value;

                            if (input.ApartmentDetails.IsFurnished.HasValue)
                                apartmentDetails.IsFurnished = input.ApartmentDetails.IsFurnished.Value;

                            if (input.ApartmentDetails.IsHaveParking.HasValue)
                                apartmentDetails.IsHaveParking = input.ApartmentDetails.IsHaveParking.Value;

                            if (!string.IsNullOrEmpty(input.ApartmentDetails.Description))
                                apartmentDetails.Description = input.ApartmentDetails.Description;

                        }
                        break;

                    case ECategoryType.ElectricalDevice:
                        var electrical = await _context.electricalAppliances
                            .FirstOrDefaultAsync(e => e.AdvertisementId == advertisement.Id);

                        if (electrical != null && input.ElectricalDevice != null)
                        {
                            if (!string.IsNullOrEmpty(input.ElectricalDevice.Brand))
                                electrical.Brand = input.ElectricalDevice.Brand;

                            if (!string.IsNullOrEmpty(input.ElectricalDevice.Model))
                                electrical.Model = input.ElectricalDevice.Model;

                            if (!string.IsNullOrEmpty(input.ElectricalDevice.Feature))
                                electrical.Feature = input.ElectricalDevice.Feature;

                            if (input.ElectricalDevice.Condition.HasValue)
                                electrical.Condition = input.ElectricalDevice.Condition.Value;

                            if (input.ElectricalDevice.IsWarranty.HasValue)
                                electrical.IsWarranty = input.ElectricalDevice.IsWarranty.Value;
                        }
                        break;

                    case ECategoryType.Works:
                        var work = await _context.works
                            .FirstOrDefaultAsync(w => w.AdvertisementId == advertisement.Id);

                        if (work != null && input.Works != null)
                        {
                            if (!string.IsNullOrEmpty(input.Works.Name))
                                work.Name = input.Works.Name;

                            if (input.Works.ServiceType.HasValue)
                                work.ServiceType = input.Works.ServiceType.Value;

                            if (input.Works.PriceType.HasValue)
                                work.PriceType = input.Works.PriceType.Value;

                            if (input.Works.BasePrice.HasValue)
                                work.BasePrice = input.Works.BasePrice.Value;

                            if (!string.IsNullOrEmpty(input.Works.Experience))
                                work.Experience = input.Works.Experience;

                            if (input.Works.Availability.HasValue)
                                work.Availability = input.Works.Availability.Value;
                        }
                        break;
                }
            

                await _context.SaveChangesAsync();
                return "Advertisement updated successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteAdvertisement(int advertisementId)
        {
            try
            {
                var advertisement = await _context.advertisements
                    .FirstOrDefaultAsync(a => a.Id == advertisementId);

                if (advertisement == null)
                    return "Advertisement not found";

                
                var carDetails = await _context.carDetails.FirstOrDefaultAsync(c => c.AdvertisementId == advertisementId);
                if (carDetails != null)
                    _context.carDetails.Remove(carDetails);

                var apartmentDetails = await _context.apartmentDetails.FirstOrDefaultAsync(a => a.AdvertisementId == advertisementId);
                if (apartmentDetails != null)
                    _context.apartmentDetails.Remove(apartmentDetails);

                var electricalDevice = await _context.electricalAppliances.FirstOrDefaultAsync(e => e.AdvertisementId == advertisementId);
                if (electricalDevice != null)
                    _context.electricalAppliances.Remove(electricalDevice);

                var work = await _context.works.FirstOrDefaultAsync(w => w.AdvertisementId == advertisementId);
                if (work != null)
                    _context.works.Remove(work);

                
                _context.advertisements.Remove(advertisement);

                await _context.SaveChangesAsync();
                return "Advertisement deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<AdvertisementOutputDTO> GetAdvertisementById(int id)
        {
            try
            {
                var advertisement = await _context.advertisements
                                    .Include(a => a.CarDetails)
                                    .Include(a => a.ApartmentDetails)
                                    .Include(a => a.ElectricalAppliance)
                                    .Include(a => a.Work)
                                    .FirstOrDefaultAsync(a => a.Id == id);

                if (advertisement == null)
                    return null;
                var result = new AdvertisementOutputDTO
                {
                    AdvertisementId = advertisement.Id,
                    Title = advertisement.Title,
                    Description = advertisement.Description,
                    Price = advertisement.Price,
                    Status = advertisement.Status,
                    Image = advertisement.Image,
                    AdvertisementType = advertisement.AdvertisementType,
                    Location = advertisement.Location,
                    CategoryId = advertisement.CategoryId,
                    UserId = advertisement.UserId,
                    CreationDate = advertisement.CreationDate,

                    CarDetails = advertisement.CarDetails != null ? new GetCarDetailsOutputDTO
                    {
                        Year = advertisement.CarDetails.Year,
                        Model = advertisement.CarDetails.Model,
                        SeatsCount = advertisement.CarDetails.SeatsCount,
                        FuelType = advertisement.CarDetails.FuelType,
                        Color = advertisement.CarDetails.Color,
                        Mileage = advertisement.CarDetails.Mileage,
                        Transmission = advertisement.CarDetails.Transmission
                    } : null,


                    ApartmentDetails = advertisement.ApartmentDetails != null ? new GetApartmentOutputDTO
                    {
                        RoomsCount = advertisement.ApartmentDetails.RoomsCount,
                        BathroomsCount = advertisement.ApartmentDetails.BathroomsCount,
                        FloorNumber = advertisement.ApartmentDetails.FloorNumber,
                        TotalFloor = advertisement.ApartmentDetails.TotalFloor,
                        Area = advertisement.ApartmentDetails.Area,
                        IsHaveBalcony = advertisement.ApartmentDetails.IsHaveBalcony,
                        IsFurnished = advertisement.ApartmentDetails.IsFurnished,
                        IsHaveElevator = advertisement.ApartmentDetails.IsHaveElevator,
                        IsHaveParking = advertisement.ApartmentDetails.IsHaveParking,
                        Description = advertisement.ApartmentDetails.Description
                    } : null,

                    ElectricalDevice = advertisement.ElectricalAppliance != null ? new GetElectricalDeviceOutputDTO
                    {
                        Brand = advertisement.ElectricalAppliance.Brand,
                        Model = advertisement.ElectricalAppliance.Model,
                        IsWarranty = advertisement.ElectricalAppliance.IsWarranty,
                        Feature = advertisement.ElectricalAppliance.Feature,
                        Condition = advertisement.ElectricalAppliance.Condition
                    } : null,

                    Works = advertisement.Work != null ? new GetWorksOutputDTO
                    {
                        Name = advertisement.Work.Name,
                        ServiceType = advertisement.Work.ServiceType,
                        PriceType = advertisement.Work.PriceType,
                        BasePrice = advertisement.Work.BasePrice.Value,
                        Experience = advertisement.Work.Experience,
                        Availability = advertisement.Work.Availability
                    } : null
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AdvertisementOutputDTO>> GetAllAdvertisements()
        {
            try
            {
                var advertisements = await _context.advertisements
                                    .Include(a => a.CarDetails)
                                    .Include(a => a.ApartmentDetails)
                                    .Include(a => a.ElectricalAppliance)
                                    .Include(a => a.Work)
                                    .ToListAsync();

                var result = advertisements.Select(ad => new AdvertisementOutputDTO
                {
                    AdvertisementId = ad.Id,
                    Title = ad.Title,
                    Description = ad.Description,
                    Price = ad.Price,
                    Status = ad.Status,
                    AdvertisementType = ad.AdvertisementType,
                    Location = ad.Location,
                    Image = ad.Image,
                    CategoryId = ad.CategoryId,
                    UserId = ad.UserId,
                    CreationDate = ad.CreationDate,
                    CarDetails = ad.CarDetails != null ? new GetCarDetailsOutputDTO
                    {
                        Year = ad.CarDetails.Year,
                        Model = ad.CarDetails.Model,
                        SeatsCount = ad.CarDetails.SeatsCount,
                        FuelType = ad.CarDetails.FuelType,
                        Color = ad.CarDetails.Color,
                        Mileage = ad.CarDetails.Mileage,
                        Transmission = ad.CarDetails.Transmission
                    } : null,
                    ApartmentDetails = ad.ApartmentDetails != null ? new GetApartmentOutputDTO
                    {
                        RoomsCount = ad.ApartmentDetails.RoomsCount,
                        BathroomsCount = ad.ApartmentDetails.BathroomsCount,
                        FloorNumber = ad.ApartmentDetails.FloorNumber,
                        TotalFloor = ad.ApartmentDetails.TotalFloor,
                        Area = ad.ApartmentDetails.Area,
                        IsHaveBalcony = ad.ApartmentDetails.IsHaveBalcony,
                        IsFurnished = ad.ApartmentDetails.IsFurnished,
                        IsHaveElevator = ad.ApartmentDetails.IsHaveElevator,
                        IsHaveParking = ad.ApartmentDetails.IsHaveParking,
                        Description = ad.ApartmentDetails.Description
                    } : null,
                    ElectricalDevice = ad.ElectricalAppliance != null ? new GetElectricalDeviceOutputDTO
                    {
                        Brand = ad.ElectricalAppliance.Brand,
                        Model = ad.ElectricalAppliance.Model,
                        IsWarranty = ad.ElectricalAppliance.IsWarranty,
                        Feature = ad.ElectricalAppliance.Feature,
                        Condition = ad.ElectricalAppliance.Condition
                    } : null,
                    Works = ad.Work != null ? new GetWorksOutputDTO
                    {
                        Name = ad.Work.Name,
                        ServiceType = ad.Work.ServiceType,
                        PriceType = ad.Work.PriceType,
                        BasePrice = ad.Work.BasePrice.Value,
                        Experience = ad.Work.Experience,
                        Availability = ad.Work.Availability
                    } : null
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<AdvertisementOutputDTO>> FilterAdvertisements(int? categoryId = null,
                        EAdvertisementType? advertisementType = null)
        {
            try
            {
                var query = _context.advertisements.AsQueryable();

                if (categoryId.HasValue)
                    query = query.Where(a => a.CategoryId == categoryId.Value);

                if (advertisementType.HasValue)
                    query = query.Where(a => a.AdvertisementType == advertisementType.Value);

                var ads = await query
                    .Select(a => new AdvertisementOutputDTO
                    {
                        AdvertisementId = a.Id,
                        Title = a.Title,
                        Description = a.Description,
                        Price = a.Price,
                        Status = a.Status,
                        AdvertisementType = a.AdvertisementType,
                        Location = a.Location,
                        CategoryId = a.CategoryId,
                        CreationDate = a.CreationDate,
                        Image = a.Image,


                        CarDetails = a.Category.CategoryType == ECategoryType.Cars ? _context.carDetails
                                        .Where(c => c.AdvertisementId == a.Id)
                                        .Select(c => new GetCarDetailsOutputDTO
                                        {
                                            CarDetailsId = c.Id,
                                            AdvertisementId = c.AdvertisementId,
                                            Model = c.Model,
                                            Year = c.Year,
                                            SeatsCount = c.SeatsCount,
                                            FuelType = c.FuelType,
                                            Transmission = c.Transmission,
                                            Color = c.Color,
                                            Mileage = c.Mileage
                                        }).FirstOrDefault() : null,

                        ApartmentDetails = a.Category.CategoryType == ECategoryType.Apartment ? _context.apartmentDetails
                                        .Where(ap => ap.AdvertisementId == a.Id)
                                        .Select(ap => new GetApartmentOutputDTO
                                        {
                                            ApartmentId = ap.Id,
                                            AdvertisementId = ap.AdvertisementId,
                                            TotalFloor = ap.TotalFloor,
                                            Area = ap.Area,
                                            RoomsCount = ap.RoomsCount,
                                            BathroomsCount = ap.BathroomsCount,
                                            FloorNumber = ap.FloorNumber,
                                            IsHaveBalcony = ap.IsHaveBalcony,
                                            IsHaveElevator = ap.IsHaveElevator,
                                            IsFurnished = ap.IsFurnished,
                                            IsHaveParking = ap.IsHaveParking,
                                            Description = ap.Description
                                        }).FirstOrDefault() : null,

                        ElectricalDevice = a.Category.CategoryType == ECategoryType.ElectricalDevice ? _context.electricalAppliances
                                        .Where(e => e.AdvertisementId == a.Id)
                                        .Select(e => new GetElectricalDeviceOutputDTO
                                        {
                                            ElectricalDeviceId = e.Id,
                                            AdvertisementId = e.AdvertisementId,
                                            Brand = e.Brand,
                                            Model = e.Model,
                                            Condition = e.Condition,
                                            IsWarranty = e.IsWarranty,
                                            Feature = e.Feature
                                        }).FirstOrDefault() : null,

                        Works = a.Category.CategoryType == ECategoryType.Works ? _context.works
                                        .Where(w => w.AdvertisementId == a.Id)
                                        .Select(w => new GetWorksOutputDTO
                                        {
                                            WorksId = w.Id,
                                            AdvertisementId = w.AdvertisementId,
                                            Name = w.Name,
                                            ServiceType = w.ServiceType,
                                            PriceType = w.PriceType,
                                            BasePrice = w.BasePrice.Value,
                                            Experience = w.Experience,
                                            Availability = w.Availability
                                        }).FirstOrDefault() : null


                    }).ToListAsync();

                return ads;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }



        public async Task<List<AdvertisementOutputDTO>> GetAdvertisementsByCategory(int categoryId)
        {
            try
            {
                var category = await _context.categories.FindAsync(categoryId);
                if (category == null)
                    throw new Exception("Category not found");

                var ads = await _context.advertisements
                    .Where(a => a.CategoryId == categoryId)
                    .Select(a => new AdvertisementOutputDTO
                    {
                        AdvertisementId = a.Id,
                        Title = a.Title,
                        Description = a.Description,
                        Price = a.Price,
                        AdvertisementType = a.AdvertisementType,
                        Location = a.Location,
                        Image = a.Image,
                        Status = a.Status,
                        UserId = a.UserId,
                        CategoryId = a.CategoryId,
                        CreationDate = a.CreationDate,
                        CarDetails = category.CategoryType == ECategoryType.Cars
                            ? _context.carDetails
                                .Where(c => c.AdvertisementId == a.Id)
                                .Select(c => new GetCarDetailsOutputDTO
                                {
                                    SeatsCount = c.SeatsCount,
                                    Model = c.Model,
                                    Year = c.Year,
                                    Mileage = c.Mileage,
                                    Transmission = c.Transmission,
                                    FuelType = c.FuelType,
                                    Color = c.Color
                                }).FirstOrDefault()
                            : null,
                        ApartmentDetails = category.CategoryType == ECategoryType.Apartment
                            ? _context.apartmentDetails
                                .Where(ap => ap.AdvertisementId == a.Id)
                                .Select(ap => new GetApartmentOutputDTO
                                {
                                    RoomsCount = ap.RoomsCount,
                                    BathroomsCount = ap.BathroomsCount,
                                    FloorNumber = ap.FloorNumber,
                                    TotalFloor = ap.TotalFloor,
                                    Area = ap.Area,
                                    IsHaveBalcony = ap.IsHaveBalcony,
                                    IsFurnished = ap.IsFurnished,
                                    IsHaveElevator = ap.IsHaveElevator,
                                    IsHaveParking = ap.IsHaveParking,
                                    Description = ap.Description
                                }).FirstOrDefault()
                            : null,
                        ElectricalDevice = category.CategoryType == ECategoryType.ElectricalDevice
                            ? _context.electricalAppliances
                                .Where(e => e.AdvertisementId == a.Id)
                                .Select(e => new GetElectricalDeviceOutputDTO
                                {
                                    Brand = e.Brand,
                                    Model = e.Model,
                                    Condition = e.Condition,
                                    Feature = e.Feature,
                                    IsWarranty = e.IsWarranty
                                }).FirstOrDefault()
                            : null,
                        Works = category.CategoryType == ECategoryType.Works
                            ? _context.works
                                .Where(w => w.AdvertisementId == a.Id)
                                .Select(w => new GetWorksOutputDTO
                                {
                                    Name = w.Name,
                                    ServiceType = w.ServiceType,
                                    PriceType = w.PriceType,
                                    BasePrice = w.BasePrice.Value,
                                    Experience = w.Experience,
                                    Availability = w.Availability
                                }).FirstOrDefault()
                            : null
                    })
                    .ToListAsync();

                return ads;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
