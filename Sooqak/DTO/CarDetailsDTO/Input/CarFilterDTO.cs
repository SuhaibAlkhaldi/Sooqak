using Sooqak.Helper.Enums.CarDetailsEnum;

namespace Sooqak.DTO.CarDetailsDTO.Input
{
    public class CarFilterDTO
    {
        public string? Model { get; set; }
        public int? Year { get; set; }
        public int? SeatsCount { get; set; }
        public EFuelType? FuelType { get; set; }
        public ETransmission? Transmission { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Location { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
