using System;
using System.Collections.Generic;

namespace task29August.Models
{
    public partial class ImageUpLoadEmployee
    {
        public int Id { get; set; }
        public string? ImgLoc { get; set; }
        public string? ExcelLoc { get; set; }
        public string? FileLoc { get; set; }
        public string? UserName { get; set; }
        public int? Price { get; set; }
    }
}
