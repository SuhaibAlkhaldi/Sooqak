using Sooqak.Helper.Enums.Work;

namespace Sooqak.DTO.WorksDTO.Input
{
    public class WorkFilterDTO
    {
        public ServiceType? ServiceType { get; set; }
        public PriceType? PriceType { get; set; }
        public decimal? MinBasePrice { get; set; }
        public decimal? MaxBasePrice { get; set; }
        public string? Experience { get; set; }
        public bool? Availability { get; set; }
        public string? Location { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
