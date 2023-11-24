namespace task29August.NewFolder.stripemodel
{
        public class  createproduct
       {
        public string name { get; set; }

        }


        public class createCheckout
        {
            public long quantity { get; set; }
            public string priceid { get; set; }

        }
        public class updateproduct
        {

            public string prodid { get; set; }
        }
        public class createprice
        {
            public long amount { get; set; }
            public string interval { get; set; }
            public string prodid { get; set; }
        public long count { get; set; }
    }
    public class createCustomer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        
    }
    public partial class cdataCustomer
    {
        public string StripeCustomerId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }

    }
    public partial class priceCustomer1
    {
        public int Id { get; set; }
        public string PriceId { get; set; } = null!;
        public int? Quantity { get; set; }

    }
    public class createPaymentMthod
    {
        public string Number { get; set; }
        public long ExpMonth { get; set; }
        public long ExpYear { get; set; }
        public string Cvc { get; set; }
      
    }
    public class updateprice
        {
            public long amount { get; set; }
            public string orderid { get; set; }
            public string priceid { get; set; }
        }
}
