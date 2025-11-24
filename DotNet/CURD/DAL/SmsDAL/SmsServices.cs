namespace CURD.DAL.SmsDAL
{
    public class SmsServices
    {
        private readonly ISms _smsRepo;
        public SmsServices(ISms smsRepo)
        {
            _smsRepo = smsRepo;
        }
        public async Task SendSms(string toPhone, string message)
        {
            await _smsRepo.SendSms(toPhone, message);
        }
    }
}