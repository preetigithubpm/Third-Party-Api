namespace task29August.NewFolder.RequestDto
{
    public class Customermodel
    {
        public int Id { get; set; }
        public string StripeCustomerId { get; set; } // This line should be present
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
