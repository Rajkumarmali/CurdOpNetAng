using System.Net;
using System.Net.Mail;

namespace CURD.DAL.EmailDAL
{
    public class EmailSenderRepo : IEmailSender
    {
        public async Task SendEmail(string subject, string body)
        {
            string fromMail = "rajkumarmali2121@gmail.com";
            string fromPassword = "mhvy yezv dddv yyro";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add("2021pcecrrajkumar013@poornima.org");
            message.Body = body;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };
            smtpClient.Send(message);
        }
    }
}
