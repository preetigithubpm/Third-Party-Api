using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29August.RequestModel;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ITwilioRestClient _twilioRestClient;

        public SmsController(ITwilioRestClient twilioRestClient)
        {
            _twilioRestClient = twilioRestClient;
        }
        [HttpPost]
        [Route("SendMessege")]
        public IActionResult sendMessege(SmsModel model)
        {
            var message = MessageResource.Create(
                to: new PhoneNumber(model.To),
                from: new PhoneNumber("+14782217937"),
                body: model.Message,
                client: _twilioRestClient);

            // Return a JSON response indicating success
            return Ok(new { message = "Success", sid = message.Sid });
        }



    }
}
