using System;
using System.Collections.Generic;

namespace task29August.Models
{
    public partial class PriceStripe
    {
        public int Id { get; set; }
        public string PriceId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public int? Quantity { get; set; }
    }
}
