using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29August.repository;
using task29August.RequestModel;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly ItokenRepostory _itoken;
        private readonly ITwoStep _register;
       
        public LoginApiController(ItokenRepostory itoken, ITwoStep register)
        {
            _itoken = itoken;
            _register = register;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("LoginApi")]
        public IActionResult loginApi(UserModel model)
        {
            IActionResult authenticatye = Unauthorized();
            var data = _itoken.LoginCredentials(model);
            return Ok(data);
        }


        [HttpPost]
        [Route("VerifyOtp")]
        public IActionResult VerifyOtp([FromBody] OtpModel model)
        {
            var obj = _register.verifyotp(model);
            return Ok(obj);
        }

        [HttpPost]
        [Route("SendOtpusingsmtp")]
        public IActionResult SendOtpusingsmtp(string Email, string Otp)
        {
            var data = _register.SendOtpToEmails(Email, Otp);
            return Ok(data);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(AddUserModel register)
        {
            var data = _register.registeruser(register);
            return Ok(data);
        }
        [HttpGet]
        [Route("GetByIdProfile")]
        public IActionResult GetByIdProfile(int id)
        {
            var obj=_itoken.GetByIdProfile(id);
            return Ok(obj); 
        }
    }
}
