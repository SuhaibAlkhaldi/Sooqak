using Sooqak.DTO.ApartmentDetailsDTO.Input;
using Sooqak.DTO.ApartmentDetailsDTO.Output;
using Sooqak.DTO.CarDetailsDTO.Input;
using Sooqak.DTO.CarDetailsDTO.Output;
using Sooqak.DTO.ElectricalDeviceDTO.Input;
using Sooqak.DTO.ElectricalDeviceDTO.Output;
using Sooqak.DTO.WorksDTO.Input;
using Sooqak.DTO.WorksDTO.Output;
using Sooqak.Helper.Enums.AdvertisementEnum;

namespace Sooqak.DTO.AdvertisementDTO.Output
{
    public class AdvertisementOutputDTO
    {
        public int AdvertisementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EAdvertisementType AdvertisementType { get; set; }
        public string Location { get; set; }
        public EAdvertisementStatus Status { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public GetCarDetailsOutputDTO? CarDetails { get; set; }
        public GetApartmentOutputDTO? ApartmentDetails { get; set; }
        public GetElectricalDeviceOutputDTO? ElectricalDevice { get; set; }
        public GetWorksOutputDTO? Works { get; set; }
    }
}
