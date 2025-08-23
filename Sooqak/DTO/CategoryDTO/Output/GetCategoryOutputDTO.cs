using Sooqak.Helper.Enums.Category;

namespace Sooqak.DTO.CategoryDTO.Output
{
    public class GetCategoryOutputDTO
    {
        public int Id { get; set; }
        public ECategoryType CategoryType { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
