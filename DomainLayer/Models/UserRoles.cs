using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class UserRoles : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int User_Id { get; set; }
        [ForeignKey("Roles")]
        public int Role_Id { get; set; }
        public Users Users { get; set; }
        public Roles Roles { get; set; }
    }
}
