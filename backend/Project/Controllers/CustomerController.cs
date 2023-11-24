using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using task29August.NewFolder.stripemodel;
using task29August.Models;
using System.Data.Entity;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpPost]
        [Route("createCustomer")]
        public async Task<IActionResult> createCustomerAsync(createCustomer customer)
        {
            sdirectdbContext _db = new sdirectdbContext();
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var options = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Description = customer.Description,


            };

            var service = new CustomerService();
            var data = service.Create(options);

            CustomerStripe sd = new CustomerStripe()
            {
                StripeCustomerId = data.Id,
                Name = customer.Name,
                Email = customer.Email

            };
            _db.CustomerStripes.Add(sd);
            _db.SaveChanges();
            return Ok(data);

        }


    }
}
