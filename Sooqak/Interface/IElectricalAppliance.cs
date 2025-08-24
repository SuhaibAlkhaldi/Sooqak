using Sooqak.DTO.ElectricalDeviceDTO.Input;
using Sooqak.DTO.ElectricalDeviceDTO.Output;

namespace Sooqak.Interface
{
    public interface IElectricalAppliance
    {

        Task<List<GetElectricalDeviceOutputDTO>> GetElectricalAppliancesByFilter(ElectricalApplianceFilterDTO filter);

    }
}
