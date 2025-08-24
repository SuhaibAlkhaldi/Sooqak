using Sooqak.DTO.ApartmentDetailsDTO.Output;
using Sooqak.DTO.WorksDTO.Input;
using Sooqak.DTO.WorksDTO.Output;
using Sooqak.Helper.Enums.Work;

namespace Sooqak.Interface
{
    public interface IWork
    {
        Task<List<GetWorksOutputDTO>> GetWorksByFilter(WorkFilterDTO filter);
    }
}
