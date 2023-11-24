using System;
using System.Collections.Generic;

namespace task29August.Models
{
    public partial class SessionStripe
    {
        public int Id { get; set; }
        public string StripeSessionId { get; set; } = null!;
        public string StripeCustomerId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
