using Sooqak.Helper.Enums.AdvertisementEnum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sooqak.Entities
{
    public class Advertisement : SharedEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EAdvertisementType AdvertisementType { get; set; }
        public string Location { get; set; }
        public EAdvertisementStatus Status { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public CarDetail CarDetails { get; set; }
        public ApartmentDetail ApartmentDetails { get; set; }
        public ElectricalAppliance ElectricalAppliance { get; set; }
        public Work Work { get; set; }
    }
}
