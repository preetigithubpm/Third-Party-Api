namespace task29August.Controllers
{
    internal class PaymentCreateRequest
    {
        public string Intent { get; set; }
        public List<PurchaseUnitRequest> PurchaseUnits { get; set; }
    }
}