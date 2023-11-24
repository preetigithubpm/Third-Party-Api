//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using PayPal.Api;
//using task29August.Stripe;

//namespace task29August.Controllers
//{
//    [ApiController]
//    [Route("api/paypal")]
//    public class PayPalController : ControllerBase
//    {
//        private readonly PayPalService _payPalService;

//        public PayPalController(PayPalService payPalService)
//        {
//            _payPalService = payPalService;
//        }

//        [HttpPost("create-payment")]
//        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest request)
//        {
//            var client = _payPalService.GetPayPalHttpClient();

//            var payment = new PaymentCreateRequest
//            {
//                Intent = "CAPTURE",
//                PurchaseUnits = new List<PurchaseUnitRequest>
//            {
//                new PurchaseUnitRequest
//                {
//                    Amount = new Money
//                    {
//                        CurrencyCode = "USD",
//                        Value = request.Amount.ToString("0.00")
//                    }
//                }
//            }
//            };

//            var response = await client.Execute(payment);
//            var result = response.Result<Payment>();

//            return Ok(new { PaymentId = result.Id });
//        }

//        [HttpPost("capture-payment")]
//        public async Task<IActionResult> CapturePayment([FromBody] CapturePaymentRequest request)
//        {
//            var client = _payPalService.GetPayPalHttpClient();

//            var capture = new CapturesCaptureRequest(request.PaymentId);

//            var response = await client.Execute(capture);
//            var result = response.Result<Capture>();

//            if (result.Status == "COMPLETED")
//            {
//                return Ok("Payment captured successfully");
//            }

//            return BadRequest("Payment capture failed");
//        }
//    }

//}
