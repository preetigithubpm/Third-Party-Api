using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Collections.Immutable;
using task29August.Models;
using task29August.RequestModel;
using task29August.Stripe;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayementWehookController : ControllerBase
    {
        const string endpointSecret = "whsec_2SPQX8GYSXdLMbHJ18ZVLyibsxxin1Td";

        [HttpPost]
        [Route("paysuccess")]
        public async Task<IActionResult> Index()
        {
            sdirectdbContext _db = new sdirectdbContext();

            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);
                string data = json;

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    Session session = new Session();
                    session = stripeEvent.Data.Object as Session;

                    /*save status or create invoice here*/

                    //var stripesession = _db.SessionStripes.Where(x => x.StripeSessionId == session.Id).FirstOrDefault();
                    var transection = _db.Transectionstripes.Where(x => x.SessionId == session.Id).FirstOrDefault();

                    if (transection == null)
                    {
                        Transectionstripe sd = new Transectionstripe()
                        {
                            Name = session.CustomerDetails.Name,
                            Email = session.CustomerDetails.Email,
                            Paymentid = stripeEvent.Id,
                            SessionId = session.Id,
                            CustomerId = session.CustomerId,
                            Mode = session.Mode,
                            Status = session.Status,
                            Type = stripeEvent.Type,
                            Subscrptionid = session.SubscriptionId,


                        };
                        _db.Transectionstripes.Add(sd);
                        _db.SaveChanges();

                    }
                    else if (transection != null)
                    {
                        transection.Name = session.CustomerDetails.Name;
                        transection.Email = session.CustomerDetails.Email;
                        transection.Paymentid = stripeEvent.Id;
                        transection.SessionId = transection.SessionId;
                        transection.CustomerId = transection.CustomerId;
                        transection.Mode = session.Mode;
                        transection.Type = stripeEvent.Type;
                        transection.Subscrptionid = session.SubscriptionId;
                        transection.Status = "paid";
                        _db.Transectionstripes.Update(transection);
                        _db.SaveChanges();
                    }
                }
                else if (stripeEvent.Type == Events.CheckoutSessionAsyncPaymentFailed)
                {
                }

                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}
