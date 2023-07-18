using DomainLayer.Models;

namespace ServiceLayer.Model
{
    public class UserModel : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Role { get; set; }
    }
}
