using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Assignment_1_Exam_Week_1.Services
{
    public class EmailService : IEmailService
    {
        private readonly Models.MailSettings _mailSettings;
        public EmailService(IOptions<Models.MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public bool SendEmailAsync(string toMail, string subject, string body)
        {
            bool emailSended = false;

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse("noreply.subaru.hr@gmail.com");
            email.To.Add(MailboxAddress.Parse(toMail));
            email.Subject = subject;
            var builder = new BodyBuilder();

            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("noreply.subaru.hr@gmail.com", "443423432");
            smtp.Send(email);
            smtp.Disconnect(true);

            emailSended = true;

            return emailSended;
        }
    }
}
