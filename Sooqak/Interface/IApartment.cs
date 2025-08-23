using Sooqak.DTO.ApartmentDetailsDTO.Output;

namespace Sooqak.Interface
{
    public interface IApartment
    {
        Task<List<GetApartmentOutputDTO>> GetApartmentByRoomsCount(int roomsCount);
        Task<List<GetApartmentOutputDTO>> GetApartmentByFloorNumber(int floorNumber);
        Task<List<GetApartmentOutputDTO>> GetApartmentByArea(double area);
        Task<List<GetApartmentByLocationDTO>> GetApartmentByLocation(string location);
        Task<List<GetApartmentByPriceDTO>> GetApartmentByPrice(decimal price);
    }
}
