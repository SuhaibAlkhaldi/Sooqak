using Sooqak.DTO.ApartmentDetailsDTO.Input;
using Sooqak.DTO.ApartmentDetailsDTO.Output;

namespace Sooqak.Interface
{
    public interface IApartment
    {
        Task<List<GetApartmentOutputDTO>> GetApartmentsByFilter(ApartmentFilterDTO filter);
    }
}
