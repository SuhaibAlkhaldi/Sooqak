namespace Sooqak.DTO.ApartmentDetailsDTO.Output
{
    public class GetApartmentOutputDTO
    {
        public int ApartmentId { get; set; }
        public int RoomsCount { get; set; }
        public int BathroomsCount { get; set; }
        public int FloorNumber { get; set; }
        public int TotalFloor { get; set; }
        public double Area { get; set; }
        public bool IsHaveBalcony { get; set; }
        public bool IsFurnished { get; set; }
        public bool IsHaveElevator { get; set; }
        public bool IsHaveParking { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Image {  get; set; }
        public decimal Price { get; set; }
        public int AdvertisementId { get; set; }
    }
}
