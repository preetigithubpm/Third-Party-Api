using System.ComponentModel.DataAnnotations;

namespace task29August.RequestModel
{
    public class DeletePatientModel
    {
        [Required(ErrorMessage = "Patient Id is required.")]
        public int PatientId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
