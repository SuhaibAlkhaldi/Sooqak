using System.ComponentModel.DataAnnotations.Schema;

namespace Sooqak.Entities
{
    public class UserFavorite : SharedEntity
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("AdvertisementId")]
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
