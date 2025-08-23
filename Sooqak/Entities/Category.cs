using Sooqak.Helper.Enums.Category;

namespace Sooqak.Entities
{
    public class Category : SharedEntity
    {
        public ECategoryType CategoryType { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
