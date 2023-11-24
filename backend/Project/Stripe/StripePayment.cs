using static PayPal.BaseConstants;
using System.ComponentModel.DataAnnotations;

namespace task29August.Stripe
{
    public record StripePayment(
         string CustomerId,
         string ReceiptEmail,
         string Description,
         string Currency,
         long Amount,
         string PaymentId);
    //public class StripeReturn
    //{
    //    public string CustomerId { get; set;}

    //}
    public class PaymentManagementVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Amount { get; set; }
        public long quantity { get; set; }
        public string productName { get; set; }
    }

    public class PaymentManagementVM1
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public long quantity { get; set; }
        public string? priceid { get; set; }
    }
    public class UpdateStudentModel
    {
 

        public int PatientId { get; set; }

    
        public string? PatientName { get; set; }

        public string? Address { get; set; }

        public DateTime? Doa { get; set; }
 
        public string? Email { get; set; }
        public IFormFile? image { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? PhoneNo { get; set; }
        public string? ImagePath { get; set; }



    }

}
