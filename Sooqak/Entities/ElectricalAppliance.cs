using Sooqak.Helper.Enums.ElectricalAppliancesEnum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sooqak.Entities
{
    public class ElectricalAppliance : SharedEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool IsWarranty { get; set; }
        public string Feature { get; set; }
        public ECondition Condition { get; set; }
        [ForeignKey("AdvertisementId")]
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
