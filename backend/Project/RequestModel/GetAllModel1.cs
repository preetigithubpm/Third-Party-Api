using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace task29August.RequestModel
{
    public class GetAllModel1
    {
        public int PatientId { get; set; }
   
        public string? PatientName { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? ImagePath { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
 
}
