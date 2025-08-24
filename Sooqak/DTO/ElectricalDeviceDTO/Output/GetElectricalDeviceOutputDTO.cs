using Sooqak.Helper.Enums.ElectricalAppliancesEnum;

namespace Sooqak.DTO.ElectricalDeviceDTO.Output
{
    public class GetElectricalDeviceOutputDTO
    {
        public int ElectricalDeviceId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool IsWarranty { get; set; }
        public string Feature { get; set; }
        public ECondition Condition { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int AdvertisementId { get; set; }
    }
}
