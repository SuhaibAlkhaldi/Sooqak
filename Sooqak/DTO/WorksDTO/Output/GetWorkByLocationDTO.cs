using Sooqak.Helper.Enums.Work;

namespace Sooqak.DTO.WorksDTO.Output
{
    public class GetWorkByLocationDTO
    {
        public int WorksId { get; set; }
        public string Name { get; set; }
        public ServiceType ServiceType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal BasePrice { get; set; }
        public string Experience { get; set; }
        public bool Availability { get; set; }
        public string Location { get; set; }
        public int AdvertisementId { get; set; }
    }
}
