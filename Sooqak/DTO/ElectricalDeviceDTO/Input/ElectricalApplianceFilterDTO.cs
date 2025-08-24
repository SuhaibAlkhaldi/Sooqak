namespace Sooqak.DTO.ElectricalDeviceDTO.Input
{
    public class ElectricalApplianceFilterDTO
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Location { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
