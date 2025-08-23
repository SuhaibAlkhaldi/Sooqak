using Sooqak.Helper.Enums.CarDetailsEnum;

namespace Sooqak.DTO.CarDetailsDTO.Input
{
    public class AddCarDetailsInputDTO
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public int SeatsCount { get; set; }
        public EFuelType FuelType { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string Mileage { get; set; }
        public ETransmission Transmission { get; set; }
        public int AdvertisementId { get; set; }
    }
}
