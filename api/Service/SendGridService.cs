using System;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace api.Service
{
    internal class SendGridService
    {
        private static void Main(string fromAddress,string toAddress,string mailContent)
        {
            Execute(fromAddress,toAddress,mailContent).Wait();
        }
        static async Task Execute(string fromAddress,string toAddress,string mailContent)
        {
            var from = new EmailAddress(fromAddress);
            var to = new EmailAddress(toAddress);
            var content = mailContent;
            var htmlContent = "<strong>Click the link given below to reset the password</strong>";
            var subject = "Password reset mail";
        }

    }
}
