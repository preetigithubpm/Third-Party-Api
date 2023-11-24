using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using task29August.NewFolder.stripemodel;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        [HttpPost]
        [Route("paymentmethod")]
        public async Task<IActionResult> paymentmethodAsync(createPaymentMthod method)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = method.Number,
                    ExpMonth = method.ExpMonth,
                    ExpYear = method.ExpYear,
                    Cvc = method.Cvc,
                },
            };
            var service = new PaymentMethodService();
            service.Create(options);
            return Ok(service.Create(options));


        }
    }
}
