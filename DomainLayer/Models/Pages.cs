using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class Pages : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? PageName { get; set; }
        public string? PageDescription { get; set; }
        public ICollection<RolePages> RolePages { get; set; }
    }
}
