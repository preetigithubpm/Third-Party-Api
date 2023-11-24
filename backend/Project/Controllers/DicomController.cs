
using FellowOakDicom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicomController : ControllerBase
    {
        public IWebHostEnvironment _environment;
        public DicomController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost("createDicomFile")]
        public IActionResult CreateDicomFile()
        {
            // Create a new DICOM dataset
            DicomDataset dataset = new DicomDataset();

            // Add necessary DICOM attributes
            dataset.AddOrUpdate(DicomTag.PatientName, "John Doe");
            dataset.AddOrUpdate(DicomTag.StudyInstanceUID, DicomUIDGenerator.GenerateDerivedFromUUID().UID);

            // Add SOP Class UID (0008,0016)
            dataset.AddOrUpdate(DicomTag.SOPClassUID, DicomUID.SecondaryCaptureImageStorage);

            // Add SOP Instance UID (0008,0018)
            dataset.AddOrUpdate(DicomTag.SOPInstanceUID, "1.3.6.1.4.1.9328.50.51.267485233220005486104148697");
            // or use a dynamic generation method based on your needs

            // Add more attributes as needed

            // Create a DICOM file from the dataset
            DicomFile dicomFile = new DicomFile(dataset);
            //if (!Directory.Exists(_environment.WebRootPath + "\\Dicom\\"))
            //{
            //    Directory.CreateDirectory(_environment.WebRootPath + "\\Dicom\\");
            //}

            //// Save the DICOM file to a file path
            //string filePath = _environment.WebRootPath + "\\Dicom\\";
            //dicomFile.Save(filePath);
            string directoryPath = Path.Combine(_environment.ContentRootPath, "Dicom");

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "file.dcm");
            dicomFile.Save(filePath);

            return Ok("DICOM file created successfully");
        }

    }
}
