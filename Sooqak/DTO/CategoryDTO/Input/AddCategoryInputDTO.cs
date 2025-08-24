using Sooqak.Helper.Enums.Category;

namespace Sooqak.DTO.CategoryDTO.Input
{
    public class AddCategoryInputDTO
    {
        public ECategoryType CategoryType { get; set; }
        public string Description { get; set; }
        public IFormFile Icon { get; set; }
    }
}
