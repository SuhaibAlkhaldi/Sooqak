using Sooqak.DTO.AuthDTO.Input;

namespace Sooqak.Interface
{
    public interface IAuth
    {
        Task<string>SignUp(SignUpInputDTO input);
        Task<string> SignIn(SignInInputDTO input);
        Task<string> ResetPassword(ResetPasswordInputDTO input);
        Task<bool> SendOTP(string email);
        Task<string> Verification(VerificationInputDTO input);
        Task<string> ToggleUserBlockStatus(int userId);
        Task<bool> SignOut(int userId);
    }
}
