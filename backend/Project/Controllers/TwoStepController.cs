using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29August.repository;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwoStepController : ControllerBase
    {
        private readonly ITwoStep _register;
        public TwoStepController(ITwoStep register)
        {
            _register = register;
        }
        
        [HttpPost]
        [Route("SendOtpusingsmtp")]
        public IActionResult SendOtpusingsmtp(string Email, string Otp)
        {
            var data = _register.SendOtpToEmails(Email, Otp);
            return Ok(data);
        }
    }
}
