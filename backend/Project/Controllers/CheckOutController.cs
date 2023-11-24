using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using task29August.NewFolder.stripemodel;

namespace task29August.Controllers.stripePayment
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        [HttpPost]
        [Route("createCheckout")]
        public async Task<IActionResult> createCheckoutAsync([FromBody] createCheckout check)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new SessionCreateOptions
            {
                SuccessUrl = "http://localhost:4200/success",
                CancelUrl = "http://localhost:4200/cancel",
                LineItems = new List<SessionLineItemOptions>
                 {
                    new SessionLineItemOptions
                    {
                      Price = check.priceid,
                      Quantity = check.quantity,
                    },
                },
                Mode = "subscription",
            };
            var service = new SessionService();
            service.Create(options);


            return Ok(service.Create(options));


        }
        [HttpPost]
        [Route("expirechecout")]
        public async Task<IActionResult> expirechecoutAsync(string id)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var service = new SessionService();
            service.Expire(id);
            return Ok(service.Expire(id));
        }
        [HttpGet]
        [Route("Acheckoutsession")]
        public async Task<IActionResult> AcheckoutsessionAsync(string id)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";
            var service = new SessionService();
            service.Get(id);
            return Ok(service);
        }
        [HttpGet]
        [Route("allcheckout")]
        public async Task<IActionResult> allcheckoutAsync()
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new SessionListOptions
            {
                Limit = 3,
            };
            var service = new SessionService();
            StripeList<Session> sessions = service.List(
              options);
            return Ok(sessions);
        }
        [HttpGet]
        [Route("sessionlineitem")]
        public async Task<IActionResult> sessionlineitemAsync(string cs_test_id)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new SessionListLineItemsOptions
            {
                Limit = 5,
            };
            var service = new SessionService();
            StripeList<LineItem> lineItems = service.ListLineItems(cs_test_id, options);
            return Ok(lineItems);
        }
    }
}
