using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class RolePages : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Roles")]
        public int Role_Id { get; set; }
        [ForeignKey("Pages")]
        public int Page_Id { get; set; }
        public Pages Pages { get; set; }
        public Roles Roles { get; set; }
    }
}
