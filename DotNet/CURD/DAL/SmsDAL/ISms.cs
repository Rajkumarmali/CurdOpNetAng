namespace CURD.DAL.SmsDAL
{
    public interface ISms
    {
        Task SendSms(string toPhone, string message);
    }
}