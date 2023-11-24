using System;
using System.Collections.Generic;

namespace task29August.Models
{
    public partial class PatientTable
    {
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? PhoneNo { get; set; }
        public string? ImagePath { get; set; }
    }
}
