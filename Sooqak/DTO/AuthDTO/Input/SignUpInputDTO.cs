using Sooqak.Helper.Enums.User;

namespace Sooqak.DTO.AuthDTO.Input
{
    public class SignUpInputDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public ELanguage SelectedLanguage { set; get; } = ELanguage.English;
    }
}
