
namespace ServiceLayer.Model
{
    public class DashboardDetailModel
    {
        public int Id { get; set; }
        public string? Dashboard_Html { get; set; }
        public string? Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? Code { get; set; }
        public int Dashboard_Id { get; set; }
    }
}
