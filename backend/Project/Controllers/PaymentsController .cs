
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using task29August.Stripe;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class PaymentsController : ControllerBase
    {
        private readonly string StripeSecretKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

        [HttpPost]
        [Route("MakePayment")]
        public IActionResult MakePayment([FromBody] PaymentRequest paymentRequest)
        {
            try
            {
                StripeConfiguration.ApiKey = StripeSecretKey;

                var token = paymentRequest.TokenId;

                var options = new PaymentIntentCreateOptions
                {
                    Amount = 10000000, // Amount in cents (1000 cents = $10.00)
                    Currency = "inr", // Set currency to Indian Rupees (INR)
                    PaymentMethodTypes = new List<string> { "card" },
                    Description = "Test Purchase using ASP.NET Core Web API",
                };

                var service = new PaymentIntentService();
                var paymentIntent = service.Create(options);

                return Ok(new { data = "success" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { data = "failure" });
            }
        }
    }
}
