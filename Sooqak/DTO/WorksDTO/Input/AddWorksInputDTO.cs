using Sooqak.Helper.Enums.Work;

namespace Sooqak.DTO.WorksDTO.Input
{
    public class AddWorksInputDTO
    {
        public string Name { get; set; }
        public ServiceType ServiceType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal BasePrice { get; set; }
        public string Experience { get; set; }
        public bool Availability { get; set; }

        public int AdvertisementId { get; set; }
    }
}
