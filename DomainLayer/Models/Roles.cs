using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class Roles : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<RolePages> RolePages { get; set; }
    }
}
