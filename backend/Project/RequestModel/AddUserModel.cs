namespace task29August.RequestModel
{
    public class AddUserModel
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }


        public int RoleId { get; set; }
    }
    public class GetByIdModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? RoleName { get; set; }

    }
}
