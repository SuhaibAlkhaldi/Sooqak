using Sooqak.DTO.CarDetailsDTO.Output;
using Sooqak.Helper.Enums.CarDetailsEnum;

namespace Sooqak.Interface
{
    public interface ICar
    {
        Task<List<GetCarDetailsOutputDTO>> GetCarsByModel(string model);
        Task<List<GetCarDetailsOutputDTO>> GetCarsByYears(int year);
        Task<List<GetCarDetailsOutputDTO>> GetCarsBySeatsCount(int seatCount);
        Task<List<GetCarDetailsOutputDTO>> GetCarsByFuelType(EFuelType fuelType);
        Task<List<GetCarDetailsOutputDTO>> GetCarsByTransmission(ETransmission transmission);
        Task<List<GetCarByPriceDTO>> GetCarsByPrice(decimal price);
        Task<List<GetCarByLocationDTO>> GetCarsByLocation(string location);
    }
}
