namespace task29August.Stripe.Payement
{
    public class PaymentRequestDto
    {
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
        // Add other relevant fields
    }

}
