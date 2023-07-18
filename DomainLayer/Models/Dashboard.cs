using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class Dashboard: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? DashboardSubName { get; set; }
        public string? Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? Code { get; set; }

        [ForeignKey("Dashboard_Boxes")]
        public int Dashboard_BoxId { get;set; }
        public Dashboard_Boxes Dashboard_Boxes { get; set; }
        public ICollection<Dashboard_Details> Dashboard_Details { get; set; }

    }
}
