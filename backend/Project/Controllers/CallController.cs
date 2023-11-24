using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29August.RequestModel;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio;
using Twilio.TwiML;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly ITwilioRestClient _twilioRestClient;

        public CallController(ITwilioRestClient twilioRestClient)
        {
            _twilioRestClient = twilioRestClient;
        }

     
            [HttpPost("voice-otp")]
            public IActionResult VoiceOtp(string otp)
            {
                var response = new VoiceResponse();
                response.Say($"Your OTP is {otp}");

                return Content(response.ToString(), "application/xml");
            }
        [HttpPost]
        [Route("callOtp")]
        public IActionResult SENDCALL(string to)
        {
            const string accountSid = "ACd2506be5f68ca409d7d48e4ce3f1c622";
            const string authToken = "7309967924ac1085a462045e96cad1c6";
            
            TwilioClient.Init(accountSid, authToken);

            // Generate OTP
            var otp = generateOtp(); // Implement your OTP generation logic

            // Make a phone call and deliver the OTP
            //var to = to // The recipient's phone number
            var from = new PhoneNumber("+14782217937");
            var to1 = new PhoneNumber(to);

           
            var call = CallResource.Create(
                to: to1,
                from: from,
                url: new Uri($"https://your-api.com/voice-otp?otp={otp}") // URL to handle the phone call and play OTP
            );
           return Ok(otp);
        }

        private object generateOtp()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();
        }
    }

}