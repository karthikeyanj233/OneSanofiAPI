
namespace ServiceLayer.Model
{
    public class DashboardModel
    {
        public int Id { get; set; }
        public string? DashboardSubName { get; set; }
        public string? Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Dashboard_BoxesId { get; set; }
        public string? Code { get; set; }
    }
}
