using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sooqak.Context;
using Sooqak.DTO.AuthDTO.Input;
using Sooqak.Entities;
using Sooqak.Helper.Email;
using Sooqak.Helper.HashingHelper;
using Sooqak.Helper.Token;
using Sooqak.Helper.Validation;
using Sooqak.Interface;


namespace Sooqak.Services
{
    public class AuthService : IAuth
    {
        private readonly SooqakDbContext _context;
        public AuthService(SooqakDbContext context)
        {
            _context = context;
        }



        public async Task<string> SignUp(SignUpInputDTO input)
        {
            try
            {
                if (ValidationHelper.IsFirstNameValid(input.FirstName) && ValidationHelper.IsLastNameValid(input.LastName)
                && ValidationHelper.IsPhoneNumberValid(input.PhoneNumber) && ValidationHelper.IsPasswordValid(input.Password)
                && ValidationHelper.IsEmailValid(input.Email))
                {
                    User user = new User();

                    user.FirstName = input.FirstName;
                    user.LastName = input.LastName;
                    user.Email = input.Email;
                    user.Password = HashingHelper.HashValueWith384(input.Password);
                    user.PhoneNumber = input.PhoneNumber;
                    user.SelectedLanguage = input.SelectedLanguage;
                    user.CreationDate = DateTime.Now;
                    user.CreatedBy = "";
                    await _context.users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    var otp = await SendOTP(user.Email);
                    await EmailHelper.SendEmail(input.Email, otp.ToString(), "Sign Up  OTP", "Complete Sign Up Operation");
                }
                return "Account Created Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            

        }


        public async Task<string> SignIn(SignInInputDTO input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.Email))
                    return "Email must be provided.";
                var user = await _context.users.Where(x => x.Email == input.Email 
                                                       && x.IsLoggedIn == false).SingleOrDefaultAsync();
                if (user == null)
                {
                    return "User not found";
                }
                

                var hashedPass = HashingHelper.HashValueWith384(input.Password);

                if (user.Password != hashedPass)
                {
                    user.NumberOfTry++;
                    if (user.NumberOfTry >= 3)
                    {
                        user.IsBlocked = true;
                        return "This account is blocked. An OTP has been sent to your email to reactivate your account.";
                    }
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    return "Invalid password.";
                }

                if (user.IsBlocked)
                {
                    var otp = await SendOTP(user.Email);
                    user.NumberOfTry = 0;
                    user.IsBlocked = false;
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    // Send OTP via email
                    await EmailHelper.SendEmail(user.Email, otp.ToString(), "Your OTP Code", $"Your OTP code is: {otp}");

                    return "This account is blocked. An OTP has been sent to your email to reactivate your account.";
                    
                }

                
                user.IsLoggedIn = true;
                _context.Update(user);
                await _context.SaveChangesAsync();

               

                var token = TokenHelper.GenerateJWTToken(user.Id, user.Email);
                return token;
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        public async Task<string> ResetPassword(ResetPasswordInputDTO input)
        {
            try
            {
                var hashedPassword = HashingHelper.HashValueWith384(input.Password);

                if (string.IsNullOrEmpty(input.Email))
                    return "Email or Phone Number must be provided." ;
                

                var user = await _context.users.Where(u => u.Email == input.Email).SingleOrDefaultAsync();
               

                if (user == null)
                {
                    return "User Not Found";
                }
                var oldPassword = await _context.users.Where(x => x.Password == user.Password).SingleOrDefaultAsync();
                if (oldPassword.Password == input.Password)
                {
                    return "New password not be the same of old password";
                }
                if (input.Password != input.ConfirmPassword)
                {
                    return "The password dose not matched";
                }
                var otp = SendOTP(input.Email);
                await EmailHelper.SendEmail(input.Email, otp.ToString(), "Reset Password", "Reset Password Done Successfully");
                user.Password = HashingHelper.HashValueWith384(input.ConfirmPassword);
                user.OTPCode = null;
                user.OTPExpiry = null;
                

                _context.Update(user);
                await _context.SaveChangesAsync();

                return "Password Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }




        public async Task<bool> SendOTP(string email)
        {
            try
            {
                var user = await _context.users.Where(u => (u.Email == email)).SingleOrDefaultAsync();
                if (user == null)
                {
                    return false;
                }
                Random otp = new Random();
                user.OTPCode = otp.Next(11111, 99999).ToString();
                user.OTPExpiry = DateTime.Now.AddMinutes(5);
                _context.Update(user);
                await _context.SaveChangesAsync();
                return true;    
            }
            catch
            {
                return false;
            }
            
        }
        

        public async Task<bool> SignOut(int userId)
        {
            try
            {
                var user = await _context.users.Where(u => u.Id == userId && u.IsLoggedIn == true).SingleOrDefaultAsync();
                if (user == null)
                {
                    return false;
                }

                user.LastLoginTime = DateTime.Now;
                user.IsLoggedIn = false;

                _context.Update(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async Task<string> Verification(VerificationInputDTO input)
        {
            try
            {
                var user = await _context.users.SingleOrDefaultAsync(u => u.Email == input.Email);
                if (user == null)
                    return "User not found.";

                if (user.OTPCode != input.OTPCode)
                    return "Invalid OTP.";

                if (user.OTPExpiry == null || DateTime.UtcNow > user.OTPExpiry.Value)
                    return "OTP expired.";

                user.OTPCode = null;
                user.OTPExpiry = null;

                _context.Update(user);
                await _context.SaveChangesAsync();

                return "OTP Verified";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




        public async Task<string> ToggleUserBlockStatus(int userId)
        {
            var user = await _context.users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            user.IsBlocked = false;
            user.NumberOfTry = 0;

            _context.users.Update(user);
            await _context.SaveChangesAsync();

            return "Account reactivated. You can login now.";
        }
    }
}
