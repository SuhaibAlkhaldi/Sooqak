using Sooqak.Helper.Enums.User;

namespace Sooqak.Entities
{
    public class User : SharedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public ELanguage SelectedLanguage { set; get; }
        public bool IsLoggedIn { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool? IsVerfied { get; set; }
        public bool IsBlocked { get; set; } = false;
        public int NumberOfTry { get; set; } = 0;
        public string? OTPCode { get; set; }
        public DateTime? OTPExpiry { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
        public ICollection<UserFavorite> UserFavorites { get; set; }
    }
}
