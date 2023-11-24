using System;
using System.Collections.Generic;

namespace task29August.Models
{
    public partial class LocationDetail
    {
        public int Payid { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public int? Uid { get; set; }
        public string? VideoLoc { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsAllotted { get; set; }
        public bool? IsActive { get; set; }
    }
}
