using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace Sooqak.Helper.Email
{
    public static class EmailHelper 
    {
        public static async Task SendEmail(string email, string code, string title, string message)
        {
            var apiKey = "";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("suhaibamjad73@gmail.com", "Sooqak Admin");
            var subject = title;
            var to = new EmailAddress(email);
            var plainTextContent = message;
            var htmlContent = "<strong>" + code + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
