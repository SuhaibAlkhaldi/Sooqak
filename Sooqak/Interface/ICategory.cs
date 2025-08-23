using Sooqak.DTO.CategoryDTO.Input;
using Sooqak.DTO.CategoryDTO.Output;

namespace Sooqak.Interface
{
    public interface ICategory
    {
        Task<string> AddCategory(AddCategoryInputDTO input);
        Task<GetCategoryOutputDTO> UpdateCategory(UpdateCategoryInputDTO input);
        Task<string> DeleteCategory(int Id);
        Task<GetCategoryOutputDTO> GetCategoryById(int Id);
        Task<List<GetCategoryOutputDTO>> GetAllCategories();
    }
}
