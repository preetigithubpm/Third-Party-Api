using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using task29August.Controllers.UpgradeDowngrade.model;
using task29August.Models;
using task29August.NewFolder.stripemodel;

namespace task29August.Controllers.UpgradeDowngrade
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProrationController : ControllerBase
    {
        [HttpPost]
        [Route("retrieveIdentifier")]
        public async Task<IActionResult> retrieveIdentifiertAsync(CustomerModel model)
        {
            
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new SubscriptionListOptions { Customer = model.customerId };
            var service = new SubscriptionService();
            StripeList<Subscription> subscriptions = service.List(options);
            return Ok(subscriptions);


        }
        [HttpPut]
        [Route("updatesubscription")]
        public async Task<IActionResult> updatesubscriptionAsync(SubscriptionModel model)
        {

            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new SubscriptionUpdateOptions
            {
                Items = new List<SubscriptionItemOptions>
                    {
                        new SubscriptionItemOptions
                        {
                            Id = model.subsitemid,
                            Price = model.newPriceid,
                        },
                    },
            };
            var service = new SubscriptionService();
            service.Update(model.subsitemid, options);

            return Ok(service.Update(model.subsitemid, options));


        }
        [HttpPost]
        [Route("createSubscription")]
        public async Task<IActionResult> createSubscriptionAsync(subscriptionDto model)
        {

            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";


            var options = new SubscriptionCreateOptions
            {
                Customer = model.customerId,
                      Items = new List<SubscriptionItemOptions>
                    {
                        new SubscriptionItemOptions { Price = model.Priceid },
                    },
            };
            var service = new SubscriptionService();
            service.Create(options);

            return Ok(service.Create(options));


        }
        [HttpPut]
        [Route("createnewSubsNewPrice")]
        public async Task<IActionResult> createnewSubsNewPriceAsync(SubscriptionModel model)
        {

            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new SubscriptionUpdateOptions
            {
                            Items = new List<SubscriptionItemOptions>
                {
                    new SubscriptionItemOptions { Id = model.subsitemid, Deleted = true },
                    new SubscriptionItemOptions { Price = model.newPriceid },
                },
            };
            var service = new SubscriptionService();
            service.Update(model.subsitemid, options);

            return Ok(service.Update(model.subsitemid, options));


        }
        [HttpPut]
        [Route("updateSubsNewPrice")]
        public async Task<IActionResult> updateSubsNewPriceAsync(SubscriptionModel model)
        {

            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";
            var options = new SubscriptionItemUpdateOptions { Price = model.newPriceid };
            var service = new SubscriptionItemService();
            service.Update(model.subsitemid, options);

            return Ok(service.Update(model.subsitemid, options));


        }
        [HttpPut]
        [Route("proration")]
        public async Task<IActionResult> prorationAsync(ProrationModel model)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";
            DateTimeOffset prorationDate = DateTimeOffset.UtcNow;

            var subService = new SubscriptionService();
            Subscription subscription = subService.Get(model.subscriptionId);

            // See what the next invoice would look like with a price switch
            // and proration set:
            var items = new List<InvoiceSubscriptionItemOptions>
                {
                  new InvoiceSubscriptionItemOptions
                  {
                    Id = subscription.Items.Data[0].Id,
                    Price = model.priceid, // switch to new price
                  },
                };

            var options = new UpcomingInvoiceOptions
            {
                Customer = model.customerid,
                Subscription = model.subscriptionId,
                SubscriptionItems = items,
                SubscriptionProrationDate = prorationDate.UtcDateTime,
            };

            var invService = new InvoiceService();
            Invoice invoice = invService.Upcoming(options);
            return Ok(invoice);
                
        }
        [HttpPost]
        [Route("updateprorationsubscription")]
        public async Task<IActionResult> updateprorationsubscriptionAsync(SubscriptionModel model)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";
            var service = new SubscriptionService();
            Subscription subscription = service.Get(model.subsitemid);

            var items = new List<SubscriptionItemOptions>
            {
                  new SubscriptionItemOptions
                  {
                      Id = subscription.Items.Data[0].Id,
                      Price = model.newPriceid,
                  },
            };
            var prorationDate = DateTime.Now;
            var options = new SubscriptionUpdateOptions
            {
                Items = items,
                ProrationDate = prorationDate,
            };
            subscription = service.Update(model.newPriceid, options);
            return Ok(subscription);

        }
        [HttpPost]
        [Route("disableProration")]
        public async Task<IActionResult> disableAsync(SubscriptionModel model)
        {
            // Set your secret key. Remember to switch to your live secret key in production.
            // See your keys here: https://dashboard.stripe.com/apikeys
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var service = new SubscriptionService();
            Subscription subscription = service.Get("sub_49ty4767H20z6a");

            var items = new List<SubscriptionItemOptions>
                {
                  new SubscriptionItemOptions
                  {
                    Id = subscription.Items.Data[0].Id,
                    Price = model.newPriceid,
                  },
                };
            var options = new SubscriptionUpdateOptions
            {
                Items = items,
                ProrationBehavior = "none",
            };
            subscription = service.Update(model.subsitemid, options);
            return Ok(subscription);
        }
        [HttpPost]
        [Route("createplan")]
        public async Task<IActionResult> createplanAsync(PlanModel model)
        {
            // Set your secret key. Remember to switch to your live secret key in production.
            // See your keys here: https://dashboard.stripe.com/apikeys
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PlanCreateOptions
            {
                Amount = model.Amount,
                Currency = "usd",
                Interval = model.Interval,
                Product = model.prodId,
            };
            var service = new PlanService();
            service.Create(options);
            return Ok(service.Create(options));
        }
        [HttpPut]
        [Route("updateplan")]
        public async Task<IActionResult> updateplanAsync(PlanUpdate model)
        {
            // Set your secret key. Remember to switch to your live secret key in production.
            // See your keys here: https://dashboard.stripe.com/apikeys
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PlanUpdateOptions
            {
                Metadata = new Dictionary<string, string> { { "order_id", "6735" } },
            };
            var service = new PlanService();
            service.Update(model.planId, options);
            return Ok(service.Update(model.planId, options));
        }
    }
}
