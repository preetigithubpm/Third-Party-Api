using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using task29August.Models;
using task29August.NewFolder.stripemodel;

namespace task29August.Controllers.stripePayment
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpPost]
        [Route("products")]
        public async Task<IActionResult> CreateProductAsync([FromBody] createproduct productname)
        {
            sdirectdbContext _db = new sdirectdbContext();
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new ProductCreateOptions
            {
                Name = productname.name,


            };
            ProductStripe tn = new ProductStripe()
            {

                Description = productname.name,

            };
            _db.ProductStripes.Add(tn);
            _db.SaveChanges();
            var service = new ProductService();
            service.Create(options);
            return Ok(service.Create(options));


        }

        [HttpPost]
        [Route("paymentmothod")]
        public async Task<IActionResult> Createpaymentmothod([FromBody] createproduct productname)
        {
            sdirectdbContext _db = new sdirectdbContext();


            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = "4242424242424242",
                    ExpMonth = 12,
                    ExpYear = 2034,
                    Cvc = "314",
                },
            };
            var service = new PaymentMethodService();
            service.Create(options);
            return Ok(service.Create(options));


        }
        [HttpGet]
        [Route("getproducts")]
        public async Task<IActionResult> GetProductAsync(string id)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var service = new ProductService();
            service.Get(id);
            return Ok(service.Get(id));
        }
        [HttpGet]
        [Route("getallproducts")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new ProductListOptions
            {
                Limit = 2,
            };
            var service = new ProductService();
            StripeList<Product> products = service.List(
              options);
            return Ok(products);
        }
        [HttpPut]
        [Route("updateProduct")]
        public async Task<IActionResult> updateProductAsync(updateproduct model)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new ProductUpdateOptions
            {
                Metadata = new Dictionary<string, string>
                  {
                    {  "order_id", "6735" },
                  },
            };
            var service = new ProductService();
            service.Update(model.prodid, options);
            return Ok(service.Update(model.prodid, options));
        }
        [HttpDelete]
        [Route("deleteProduct")]
        public async Task<IActionResult> deleteProductAsync(string prodid)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var service = new ProductService();
            service.Delete(prodid);
            return Ok(prodid + "deleted");
        }
        [HttpGet]
        [Route("searchProduct")]
        public async Task<IActionResult> searchProductAsync()
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new ProductSearchOptions
            {
                Query = "active:'true' AND metadata['order_id']:'6735'",
            };
            var service = new ProductService();
            service.Search(options);
            return Ok(service.Search(options));
        }
    }
}

