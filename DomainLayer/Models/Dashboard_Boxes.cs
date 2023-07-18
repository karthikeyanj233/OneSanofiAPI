using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class Dashboard_Boxes : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? DashboardHeaderName { get; set; }
        public string? Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? Code { get; set; }
        public ICollection<Dashboard> Dashboard { get; set; }
    }
}
