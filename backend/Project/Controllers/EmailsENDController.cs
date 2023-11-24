using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29August.NewFolder.RequestDto;
using task29August.repository;
using task29August.RequestModel;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsENDController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IEmail _rep;

        public EmailsENDController(IEmailService emailService, IEmail rep)
        {
            _emailService = emailService;
            _rep = rep;
        }
        [HttpPost]
        [Route("SendEmail")]
        public IActionResult SendEmailTo()
        {

            var message = new Message(new string[] { "preeti78198606@gmail.com" }, "Test", "Hello Smartian");
            _emailService.SendEmail(message);
            return Ok("Email sent successfully.");

        }
       
        [HttpPost]
        [Route("SedingMialFrontEnd")]
        public async Task<IActionResult> sendingMail(MailRequest model)
        {
            try
            {
                MailRequest mail1 = new MailRequest();
                mail1.ToEmail = model.ToEmail;
                mail1.Subject = model.Subject;
                mail1.Body = model.Body;
                await _rep.SendingMailAsync(mail1);

                // Return a JSON response indicating success
                return Ok(new { message = "Email Sent Successfully" });
            }
            catch (Exception ex)
            {
                // Return a JSON response indicating an error
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

    }
}

