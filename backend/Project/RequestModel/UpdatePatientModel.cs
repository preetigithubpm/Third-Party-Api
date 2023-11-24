using System.ComponentModel.DataAnnotations;

namespace task29August.RequestModel
{
    public class UpdatePatientModel
    {
        [Required(ErrorMessage = "Id is required.")]

        public int PatientId { get; set; }

        [Required(ErrorMessage = "Patient Name is required.")]
        public string? PatientName { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Patient dob is required.")]
        public DateTime? Dob { get; set; }
        [Required(ErrorMessage = "Patient email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
    }
}
