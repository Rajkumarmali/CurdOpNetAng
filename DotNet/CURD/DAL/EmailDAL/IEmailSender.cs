namespace CURD.DAL.EmailDAL
{
    public interface IEmailSender
    {
        Task SendEmail(string subject, string body);
    }
}
