using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using task29August.NewFolder.stripemodel;

namespace task29August.Controllers.stripePayment
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        [HttpPost]
        [Route("createpaymentlink")]
        public async Task<IActionResult> createpaymentlinkAsync([FromBody] createCheckout paylink)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PaymentLinkCreateOptions
            {
                LineItems = new List<PaymentLinkLineItemOptions>
                  {
                    new PaymentLinkLineItemOptions
                    {
                      Price = paylink.priceid,
                      Quantity = paylink.quantity,
                    },
                  },
            };
            var service = new PaymentLinkService();
            service.Create(options);

            return Ok(service.Create(options));


        }

        [HttpPost]
        [Route("redirecttopayment")]
        public async Task<IActionResult> redirecttopaymentAsync(string paylink)
        {

            string link = "https://buy.stripe.com/test_fZe4hD4oY1zL8ms6oF";
            return Ok(link);


        }
        [HttpGet]
        [Route("getpaymentlink")]
        public async Task<IActionResult> getpaymentlinkAsync(string paylinkid)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var service = new PaymentLinkService();
            service.Get(paylinkid);
            return Ok(service.Get(paylinkid));
        }
        [HttpGet]
        [Route("getallpaylink")]
        public async Task<IActionResult> getallpaylinkAsync()
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PaymentLinkListOptions
            {
                Limit = 3,
            };
            var service = new PaymentLinkService();
            StripeList<PaymentLink> paymentLinks = service.List(
              options);
            return Ok(paymentLinks);
        }
        [HttpPut]
        [Route("updateProduct")]
        public async Task<IActionResult> updateProductAsync(string paylinkid)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PaymentLinkUpdateOptions
            {
                Active = false,
            };
            var service = new PaymentLinkService();
            service.Update(paylinkid, options);
            return Ok(service.Update(paylinkid, options));
        }
        [HttpGet]
        [Route("paylinklineitem")]
        public async Task<IActionResult> paylinklineitemAsync(string paylinkid)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PaymentLinkListLineItemsOptions
            {
                Limit = 3,
            };
            var service = new PaymentLinkService();
            StripeList<LineItem> lineItems = service.ListLineItems(paylinkid, options);
            return Ok(lineItems);
        }
    }
}
