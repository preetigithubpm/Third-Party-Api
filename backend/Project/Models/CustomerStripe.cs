using System;
using System.Collections.Generic;

namespace task29August.Models
{
    public partial class CustomerStripe
    {
        public int Id { get; set; }
        public string StripeCustomerId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
