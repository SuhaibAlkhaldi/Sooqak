using Sooqak.Helper.Enums.Category;

namespace Sooqak.DTO.CategoryDTO.Input
{
    public class UpdateCategoryInputDTO
    {
        public int Id { get; set; }
        public ECategoryType? CategoryType { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }
}
