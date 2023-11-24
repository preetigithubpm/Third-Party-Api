using System;
using System.Collections.Generic;

namespace task29August.Models
{
    public partial class CartbookDetail
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
