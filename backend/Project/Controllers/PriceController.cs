using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using task29August.Models;
using task29August.NewFolder.stripemodel;

namespace task29August.Controllers.stripePayment
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        [HttpPost]
        [Route("createprice")]
        public async Task<IActionResult> createpriceAsync(createprice model)
        {
            sdirectdbContext _db = new sdirectdbContext();
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PriceCreateOptions
            {
                UnitAmount = (model.amount) * 100,
                Currency = "usd",
                Recurring = new PriceRecurringOptions
                {
                    Interval = model.interval,
                    IntervalCount=model.count,
                },
                Product = model.prodid,
            };

            var service = new PriceService();
            service.Create(options);
            var data = service.Create(options);

            PriceStripe sd = new PriceStripe()
            {
                PriceId = data.Id,
                ProductId = data.ProductId,


            };
            _db.PriceStripes.Add(sd);

            _db.SaveChanges();
            var obj = _db.PriceStripes.FirstOrDefault(x => x.ProductId == data.ProductId);
            if (obj != null)
            {
                ProductStripe tn = new ProductStripe()
                {
                    ProductId = data.ProductId,
                    ProductName = data.Id,
                    Description = data.Type,
                    IsActive = true,
                    IsDeleted = false,
                };
                _db.ProductStripes.Add(tn);
                _db.SaveChanges();
            }
            return Ok(service.Create(options));
        }
        [HttpGet]
        [Route("getprice")]
        public async Task<IActionResult> getpriceAsync(string prodid)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var service = new PriceService();
            service.Get(prodid);
            return Ok(service.Get(prodid));
        }
        [HttpPut]
        [Route("updatePrice")]
        public async Task<IActionResult> updateProductAsync(updateprice model)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PriceUpdateOptions
            {
                Metadata = new Dictionary<string, string>
                  {
                    { "order_id", model.orderid },
                  },
            };
            var service = new PriceService();
            service.Update(model.priceid, options);
            return Ok(service.Update(model.priceid, options));
        }
        [HttpGet]
        [Route("getallprice")]
        public async Task<IActionResult> getallpriceAsync()
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PriceListOptions { Limit = 3 };
            var service = new PriceService();
            StripeList<Price> prices = service.List(options);
            return Ok(prices);
        }
        [HttpGet]
        [Route("searchPrice")]
        public async Task<IActionResult> searchProductAsync()
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PriceSearchOptions
            {
                Query = "active:'true' AND metadata['order_id']:'6735'",
            };
            var service = new PriceService();
            service.Search(options);
            return Ok(service.Search(options));
        }
    }
}
