using Sooqak.DTO.AdvertisementDTO.Input;
using Sooqak.DTO.AdvertisementDTO.Output;
using Sooqak.Helper.Enums.AdvertisementEnum;

namespace Sooqak.Interface
{
    public interface IAdvertisement
    {
        Task<string> AddAdvertisement(AddAdvertisementInputDTO input);
        Task<string> UpdateAdvertisement(UpdateAdvertisementInputDTO input);
        Task<string> DeleteAdvertisement(int advertisementId);
        Task<AdvertisementOutputDTO> GetAdvertisementById(int id);
        Task<List<AdvertisementOutputDTO>> GetAllAdvertisements();
        Task<List<AdvertisementOutputDTO>> FilterAdvertisements(int? categoryId = null,
            EAdvertisementType? advertisementType = null);

        Task<List<AdvertisementOutputDTO>> GetAdvertisementsByCategory(int categoryId);
    }
}
