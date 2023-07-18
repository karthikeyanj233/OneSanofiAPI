
namespace ServiceLayer.Model
{
    public class DashboardBoxModel
    {
        public int Id { get; set; }
        public string? DashboardHeaderName { get; set; }
        public string? Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? Code { get; set; }
    }
}
