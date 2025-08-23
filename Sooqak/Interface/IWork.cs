using Sooqak.DTO.ApartmentDetailsDTO.Output;
using Sooqak.DTO.WorksDTO.Output;
using Sooqak.Helper.Enums.Work;

namespace Sooqak.Interface
{
    public interface IWork
    {
        Task<List<GetWorksOutputDTO>> GetWorkByService(ServiceType service);
        Task<List<GetWorksOutputDTO>> GetWorkByPriceType(PriceType priceType);
        Task<List<GetWorksOutputDTO>> GetWorkByBasePrice(decimal basePrice);
        Task<List<GetWorksOutputDTO>> GetWorkByExperience(string experience);
        Task<List<GetWorksOutputDTO>> GetWorkByAvailability(bool isAvailable);
        Task<List<GetWorkByLocationDTO>> GetWorkByLocation(string location);
    }
}
