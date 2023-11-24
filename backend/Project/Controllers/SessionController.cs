using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using task29August.Models;
using task29August.ResponseModel;
using task29August.Stripe;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        [HttpPost]
        [Route("createSessionpriceid")]
        public async Task<StripeReturn> createSessionpriceid(PaymentManagementVM1 paymentManagementVM, string? CustomerId)
        {
            sdirectdbContext _db = new sdirectdbContext();
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";
            var session = new Session();

            var sessionStripe = _db.SessionStripes.FirstOrDefault(x => x.Email == paymentManagementVM.Email);

            if (sessionStripe == null)
            {
                // Check if StripeCustomerId is null before accessing it
                if (sessionStripe?.StripeCustomerId == null)
                {

                    CustomerCreateOptions customerOptions = new CustomerCreateOptions
                    {
                        Name = paymentManagementVM.Name,
                        Email = paymentManagementVM.Email,
                    };

                    CustomerService customer = new CustomerService();

                    Customer createdCustomer = customer.Create(customerOptions);
                    CustomerId = createdCustomer.Id;
                }
                else
                {
                    // If StripeCustomerId is not null, assign it to CustomerId
                    CustomerId = sessionStripe.StripeCustomerId;
                }
            }
            else
            {
                // If sessionStripe is not null, assign StripeCustomerId to CustomerId
                CustomerId = sessionStripe.StripeCustomerId;
            }

            //Create session starts here
            var options = new SessionCreateOptions
            {
                Customer = CustomerId,
                SuccessUrl = "http://localhost:4200/success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "http://localhost:4200/cancel",
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Price = paymentManagementVM.priceid,
                    Quantity = paymentManagementVM.quantity,
                },
            },
                Mode = "subscription",
            };


            var service = new SessionService();
            session = service.Create(options);
            //Create session ends here

            if (sessionStripe != null)
            {
                //update session stripe here
                sessionStripe.StripeSessionId = session.Id;
                sessionStripe.StripeCustomerId = CustomerId;
                sessionStripe.Name = paymentManagementVM.Name;
                sessionStripe.Email = paymentManagementVM.Email;

                _db.SessionStripes.Update(sessionStripe);
                _db.SaveChanges();

            }
            else
            {
                //add session stripe here

                SessionStripe sd = new SessionStripe()
                {
                    StripeSessionId = session.Id,
                    StripeCustomerId = session.CustomerId,
                    Name = paymentManagementVM.Name,
                    Email = paymentManagementVM.Email,
                };
                _db.SessionStripes.Add(sd);
                _db.SaveChanges();
                sessionStripe = sd;
            }

            Transectionstripe tn = new Transectionstripe()
            {
                SessionId = session.Id,
                CustomerId = session.CustomerId,
                Name = session.CustomerDetails.Name,
                Email = session.CustomerDetails.Email,
                Status = "pending",
                Type = session.SubmitType,
                Paymentid = session.PaymentIntentId,
            };
            _db.Transectionstripes.Add(tn);
            _db.SaveChanges();

            return new StripeReturn()
            {
                Session = session,
                CustomerId = CustomerId
            };



        }
        [HttpGet("sessionid")]
        public Response1 CheckPaymentStatus(string sessionid)
        {
            Response1 res = new Response1();
            sdirectdbContext _db = new sdirectdbContext();
            var payment = _db.Transectionstripes.FirstOrDefault(x => x.SessionId == sessionid);
            if (payment == null)
            {
                res.ResponseMessage = "Not Found";
                res.ResponseCode = 404;
                return res;
            }

            if (payment.Status == "paid")
            {
                res.ResponseMessage = "paid";
                res.ResponseCode = 200;
                return res;
            }
            res.ResponseMessage = "pending";
            res.ResponseCode = 500;
            return res;
        }











































        [HttpPost]
        [Route("createSession")]
        public StripeReturn Post(PaymentManagementVM paymentManagementVM, string? CustomerId)
        {
            sdirectdbContext _db = new sdirectdbContext();
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";
            var session = new Session();

            if (CustomerId == null)
            {
                CustomerCreateOptions customerOptions = new CustomerCreateOptions
                {
                    Name = paymentManagementVM.Name,
                    Email = paymentManagementVM.Email,
                };
                CustomerService customer = new CustomerService();
                Customer createdCustomer = customer.Create(customerOptions);
                CustomerId = createdCustomer.Id;
            }
            var options = new SessionCreateOptions
            {
                Customer = CustomerId,
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (paymentManagementVM.Amount) * 100,
                        Currency = "usd",

                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = paymentManagementVM.productName,
                        },
                    },
                    Quantity = paymentManagementVM.quantity,
                }
            },
                BillingAddressCollection = "auto",
                PaymentIntentData = new SessionPaymentIntentDataOptions()
                {
                    SetupFutureUsage = "on_session"
                },
                Mode = "payment",
                SuccessUrl = "http://localhost:4200/success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "http://localhost:4200/cancel",
            };



            var service = new SessionService();
            session = service.Create(options);
            SessionStripe sd = new SessionStripe()
            {
                StripeSessionId = session.Id,
                StripeCustomerId = session.CustomerId,
                Name = paymentManagementVM.Name,
                Email = paymentManagementVM.Email,
            };
            _db.SessionStripes.Add(sd);
            _db.SaveChanges();
            if (session.Id == sd.StripeSessionId && session.CustomerId == sd.StripeCustomerId)
            {
                return new StripeReturn()
                {
                    Session = session,
                    CustomerId = CustomerId,
                };

            }
            else
            {
                return new StripeReturn()
                {
                    Session = session,
                    CustomerId = CustomerId,
                };
            }

        }

        [HttpGet]
        [Route("getSessionPayment")]
        public async Task<IActionResult> getSessionPaymentAsync(string sessionid)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy";

            var service = new SessionService();
            service.Get(sessionid);
            return Ok(service.Get(sessionid));
        }
        [HttpGet]
        [Route("getProduct")]
        public Product GetProduct(string productId)
        {
            StripeConfiguration.ApiKey = "sk_test_51NoJbgSHgVxrrED8VQdvN5bgwUt3oG3dQ2ce6obU0vm95xsw4yn98yh05gPrA8s5asWC6huh557bNlEEavnJ0VwV00cjzUddMy"; // Replace with your Stripe API key

            try
            {
                var productService = new ProductService();
                var product = productService.Get(productId);

                if (product != null)
                {
                    return product;
                }
                else
                {
                    // Product not found, return null or handle the error accordingly
                    return null;
                }
            }
            catch (StripeException ex)
            {
                // Handle any Stripe API errors here
                // You can log the error, return an error response, etc.
                return null;
            }
        }


    }
}
