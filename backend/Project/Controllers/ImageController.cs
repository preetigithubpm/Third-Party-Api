using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29August.Images;
using task29August.Models;

namespace task29August.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ImageController : ControllerBase
    {
        public IWebHostEnvironment _environment;

        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


       
        [HttpPost]
        [Route("Uploading")]
      
        public async Task<IActionResult> uploadImage([FromForm] ImageUploadModel objFile)
        {
            try
            {
                ImageUpLoadEmployee obj = new ImageUpLoadEmployee();
                sdirectdbContext _db = new sdirectdbContext();

                if (objFile.images.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }

                    string val = DateTime.Now.ToString();
                    val = val.Replace("-", string.Empty);
                    val = val.Replace(":", string.Empty);
                    val = val.Replace(" ", string.Empty);

                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath +val+ "\\Upload\\"  + objFile.images.FileName))
                    {
                        objFile.images.CopyTo(fileStream);
                        fileStream.Flush();
                        obj.ImgLoc = "\\Upload\\" + val + objFile.images.FileName;
                        obj.ExcelLoc = objFile.ExcelLoc;
                        obj.UserName= objFile.UserName;
                        obj.FileLoc = objFile.FileLoc;
                        obj.Price = objFile.Price;
                        _db.ImageUpLoadEmployees.Add(obj);
                        _db.SaveChanges();

                        // Return the file path as JSON
                        return Ok(new { ImgLoc = obj.ImgLoc });
                    }
                }
                else
                {
                    return Ok(new { ImgLoc = "Failed" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
        [HttpGet]
        [Route("GetImage/{imageId}")]
        public IActionResult GetImage(int imageId)
        {
            try
            {
                sdirectdbContext _db = new sdirectdbContext();
                var image = _db.ImageUpLoadEmployees.Find(imageId);

                if (image != null)
                {
                    // Construct the full path to the image
                    var imagePath = Path.Combine(_environment.WebRootPath, image.ImgLoc.TrimStart('\\'));

                    // Check if the file exists
                    if (System.IO.File.Exists(imagePath))
                    {
                        // Read the file as bytes and return it as a FileResult
                        byte[] fileBytes = System.IO.File.ReadAllBytes(imagePath);
                        return File(fileBytes, "image/jpeg"); // You can specify the appropriate content type here
                    }
                    else
                    {
                        return NotFound(); // Image not found
                    }
                }
                else
                {
                    return NotFound(); // Image with the specified ID not found
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
        [HttpGet]
        [Route("GetAllImagesTHroughDeatils")]
        public IActionResult GetAllImagesTHroughDeatils()
        {
            try
            {
                GetImageUploadModel obj = new GetImageUploadModel();
                ImageUploadModel model = new ImageUploadModel();


                sdirectdbContext _db = new sdirectdbContext();
                var images = _db.ImageUpLoadEmployees.OrderByDescending(img => img.Id).ToList(); // Retrieve all images from the database

                // Create a list to store image URLs
                List<string> imageUrls = new List<string>();

                foreach (var image in images)
                {
                    // Construct the full path to each image
                    var imagePath = Path.Combine(_environment.WebRootPath, image.ImgLoc.TrimStart('\\'));

                    // Check if the file exists
                    if (System.IO.File.Exists(imagePath))
                    {
                        // Get the relative URL of the image
                        var imageUrl = image.ImgLoc; // Remove the extra "\\"

                        // Add the image URL to the list
                        imageUrls.Add(imageUrl);
                        obj.FileLoc = model.FileLoc;
                        obj.ExcelLoc = model.ExcelLoc;
                        obj.UserName = model.UserName;
                        obj.Price=model.Price;
                        obj.ImgLoc = imageUrl;

                    }
                }

                return Ok(images);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }


        [HttpGet]
        [Route("GetAllImages")]
        public IActionResult GetAllImages()
        {
            try
            {
                sdirectdbContext _db = new sdirectdbContext();
                var images = _db.ImageUpLoadEmployees.OrderByDescending(img => img.Id).ToList(); // Retrieve all images from the database

                // Create a list to store image URLs
                List<string> imageUrls = new List<string>();

                foreach (var image in images)
                {
                    // Construct the full path to each image
                    var imagePath = Path.Combine(_environment.WebRootPath, image.ImgLoc.TrimStart('\\'));

                    // Check if the file exists
                    if (System.IO.File.Exists(imagePath))
                    {
                        // Get the relative URL of the image
                        var imageUrl =  image.ImgLoc; // Remove the extra "\\"

                        // Add the image URL to the list
                        imageUrls.Add(imageUrl);
                    }
                }

                return Ok(imageUrls);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }




    }
}
