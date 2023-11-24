namespace task29August.Images
{
    public class ImageUploadModel
    {
        public IFormFile images { get; set; }
        public string? ExcelLoc { get; set; }
        public string? UserName { get; set; }
        public string? FileLoc { get; set; }
        public int? Price { get; set; }
    }
}
