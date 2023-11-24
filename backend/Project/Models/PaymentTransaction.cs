using System;
using System.Collections.Generic;

namespace task29August.Models
{
    public partial class PaymentTransaction
    {
        public int TransactionId { get; set; }
        public decimal? Amount { get; set; }
        public string? PaymentStatus { get; set; }
        public int? UserId { get; set; }
        public int? PaymentMethodId { get; set; }
    }
}
