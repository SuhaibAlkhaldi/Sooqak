using Sooqak.DTO.CarDetailsDTO.Input;
using Sooqak.DTO.CarDetailsDTO.Output;
using Sooqak.Helper.Enums.CarDetailsEnum;

namespace Sooqak.Interface
{
    public interface ICar
    {
        Task<List<GetCarDetailsOutputDTO>> GetCarsByFilter(CarFilterDTO filter);

    }
}
