using Sooqak.DTO.ApartmentDetailsDTO.Input;
using Sooqak.DTO.CarDetailsDTO.Input;
using Sooqak.DTO.ElectricalDeviceDTO.Input;
using Sooqak.DTO.WorksDTO.Input;
using Sooqak.Helper.Enums.AdvertisementEnum;

namespace Sooqak.DTO.AdvertisementDTO.Input
{
    public class UpdateAdvertisementInputDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public EAdvertisementType? AdvertisementType { get; set; }
        public string? Location { get; set; }
        public EAdvertisementStatus? Status { get; set; }
        public UpdateCarDetailsInputDTO? CarDetails { get; set; }
        public UpdateApartmentInputDTO? ApartmentDetails { get; set; }
        public UpdateElectricalDeviceInputDTO? ElectricalDevice { get; set; }
        public UpdateWorksInputDTO? Works { get; set; }
    }
}
