using Microsoft.AspNetCore.Http.HttpResults;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CURD.DAL.SmsDAL
{
    public class SmsRepo : ISms
    {
        private readonly string _accountSid = "";
        private readonly string _authToken = "";
        private readonly string _fromPhone = "";
        public SmsRepo()
        {
            TwilioClient.Init(_accountSid, _authToken);
        }
        public async Task SendSms(string toPhone, string message)
        {
            var msg = await MessageResource.CreateAsync(
                body: message,
                from: new Twilio.Types.PhoneNumber(_fromPhone),
                to: new Twilio.Types.PhoneNumber(toPhone)
            );
        }
    }
}