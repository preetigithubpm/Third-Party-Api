namespace task29August.Controllers
{
    internal class CapturesCaptureRequest : PaymentCreateRequest
    {
        private object paymentId;

        public CapturesCaptureRequest(object paymentId)
        {
            this.paymentId = paymentId;
        }
    }
}