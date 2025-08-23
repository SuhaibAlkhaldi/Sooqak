using Sooqak.DTO.ElectricalDeviceDTO.Output;

namespace Sooqak.Interface
{
    public interface IElectricalAppliance
    {
        Task<List<GetElectricalDeviceOutputDTO>> GetElectricalApplianceByBrand(string brand);
        Task<List<GetElectricalDeviceOutputDTO>> GetElectricalApplianceByModel(string model);
        Task<List<GetElectricalApplianceByLocationDTO>> GetElectricalApplianceByLocation(string location);

        Task<List<GetElectricalApplianceByPriceDTO>> GetElectricalApplianceByPrice(decimal price);

    }
}
