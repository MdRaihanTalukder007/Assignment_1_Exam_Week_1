namespace Assignment_1_Exam_Week_1.Services
{
    public interface IEmailService
    {
        bool SendEmailAsync(string toMail, string subject, string body);
    }
}
