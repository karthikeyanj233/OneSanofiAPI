namespace RepositoryLayer.Model
{
    public class DashboardHeader
    {
        public int Id { get; set; }
        public string HeaderName { get; set; }
        public string Code { get; set; }
        public ICollection<DashboardLists> DashboardLists { get; set; }
    }
    public class DashboardLists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
