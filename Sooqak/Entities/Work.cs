using Sooqak.Helper.Enums.Work;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Sooqak.Entities
{
    public class Work : SharedEntity
    {
        public string Name { get; set; }
        public ServiceType ServiceType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? BasePrice { get; set; }
        public string Experience { get; set; }
        public bool Availability { get; set; }
        [ForeignKey("AdvertisementId")]
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }

    }
}
