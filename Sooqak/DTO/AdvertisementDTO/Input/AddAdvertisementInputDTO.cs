using Sooqak.DTO.ApartmentDetailsDTO.Input;
using Sooqak.DTO.CarDetailsDTO.Input;
using Sooqak.DTO.ElectricalDeviceDTO.Input;
using Sooqak.DTO.WorksDTO.Input;
using Sooqak.Entities;
using Sooqak.Helper.Enums.AdvertisementEnum;
using Sooqak.Helper.Enums.CarDetailsEnum;
using Sooqak.Helper.Enums.ElectricalAppliancesEnum;
using Sooqak.Helper.Enums.Work;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sooqak.DTO.AdvertisementDTO.Input
{
    public class AddAdvertisementInputDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EAdvertisementType AdvertisementType { get; set; }
        public string Location { get; set; }
        public EAdvertisementStatus Status { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public AddCarDetailsInputDTO? CarDetails { get; set; }
        public AddApartmentDetailsInputDTO? ApartmentDetails { get; set; }
        public AddElectricalDeviceInputDTO? ElectricalDevice { get; set; }
        public AddWorksInputDTO? Works { get; set; }
    }

}
