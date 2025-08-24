namespace Sooqak.DTO.ApartmentDetailsDTO.Input
{
    public class ApartmentFilterDTO
    {
        public int? RoomsCount { get; set; }
        public int? FloorNumber { get; set; }
        public double? MinArea { get; set; }
        public double? MaxArea { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Location { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
