using System;
using System.Collections.Generic;

namespace task29August.Models
{
    public partial class Loginvalidate2
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool? IsAuthenticate { get; set; }
        public string? Otp { get; set; }
    }
}
