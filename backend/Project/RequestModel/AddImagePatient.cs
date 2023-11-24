using System.ComponentModel.DataAnnotations;

namespace task29August.RequestModel
{
    public class AddImagePatient
    {
        public string? PatientName { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public string? Email { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? image { get; set; }
        public string? PhoneNo { get; set; }
    }
    public class AddImagePatient1
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string? ImagePath { get; set; }

    }
    public class DetailModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public int? uid { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

    }
    public class LocationDetailModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public int Uid { get; set; }
        public IFormFile VideoLoc { get; set; }
    }
}
