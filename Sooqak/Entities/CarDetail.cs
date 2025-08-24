using Sooqak.Helper.Enums.CarDetailsEnum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sooqak.Entities
{
    public class CarDetail : SharedEntity
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public int SeatsCount { get; set; }
        public EFuelType FuelType { get; set; }
        public string Color { get; set; }
        public string Mileage { get; set; }
        public ETransmission Transmission { get; set; }
        [ForeignKey("AdvertisementId")]
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
