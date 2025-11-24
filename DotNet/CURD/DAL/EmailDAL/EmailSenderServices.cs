namespace CURD.DAL.EmailDAL
{
    public class EmailServices
    {
        private readonly IEmailSender _emailRepo;

        public EmailServices(IEmailSender emailRepo)
        {
            _emailRepo = emailRepo;
        }

        public async Task SendEmailAsync(string sub, string body)
        {
            await _emailRepo.SendEmail(sub, body);
        }
    }
}
