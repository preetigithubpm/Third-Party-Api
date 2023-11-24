namespace task29August.Controllers
{
    public class DicomModel
    {
        public IFormFile DicomImage { get; set; }
        public string? PatientName { get; set; }
        public string? DicomName { get; set; }
        public string? FileLoc { get; set; }
       
    }
}