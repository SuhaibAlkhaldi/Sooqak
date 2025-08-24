using System.ComponentModel.DataAnnotations.Schema;

namespace Sooqak.Entities
{
    public class ApartmentDetail : SharedEntity
    {
        public int RoomsCount { get; set; }
        public int BathroomsCount { get; set; }
        public int FloorNumber { get; set; }
        public int TotalFloor {  get; set; }
        public double Area { get; set; }
        public bool IsHaveBalcony { get; set; }
        public bool IsFurnished { get; set; }
        public bool IsHaveElevator { get; set; }
        public bool IsHaveParking { get; set; }
        public string Description { get; set; }
        [ForeignKey("AdvertisementId")]
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        
    }
}
