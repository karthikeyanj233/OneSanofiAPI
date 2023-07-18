using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class Dashboard_Details: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Dashboard_Html { get; set; }
        public string? Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? Code { get; set; }

        [ForeignKey("Dashboard")]
        public int Dashboard_Id { get; set; }
        public Dashboard Dashboard { get; set; }
    }
}
