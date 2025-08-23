using Sooqak.Helper.Enums.ElectricalAppliancesEnum;

namespace Sooqak.DTO.ElectricalDeviceDTO.Input
{
    public class AddElectricalDeviceInputDTO
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool IsWarranty { get; set; }
        public string Feature { get; set; }
        public ECondition Condition { get; set; }

        public int AdvertisementId { get; set; }
    }
}
