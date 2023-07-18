using DomainLayer.Models;
using RepositoryLayer.IRepository;
using RepositoryLayer.Model;
using ServiceLayer.IDashboardServices;

namespace ServiceLayer.DashboardServices
{
    public class DashboardHeaderService : IDashboardHeaderService<DashboardHeader>
    {
        private readonly IRepository<Dashboard_Boxes> _dashboardboxRepository;
        private readonly IRepository<Dashboard> _dashboardService;

        public DashboardHeaderService(IRepository<Dashboard_Boxes> dashboardboxRepository, IRepository<Dashboard> dashboardService)
        {
            _dashboardboxRepository = dashboardboxRepository;
            _dashboardService = dashboardService;
        }

        public IEnumerable<DashboardHeader> GetAllDashboard()
        {
            try
            {
                List<DashboardHeader> dashboardHeaders = new List<DashboardHeader>();
                var dsshboardbox = _dashboardboxRepository.GetAll();
                foreach (var item in dsshboardbox)
                {
                    DashboardHeader dashboardmodel = new DashboardHeader();
                    dashboardmodel.Id = item.Id;
                    dashboardmodel.HeaderName = item.DashboardHeaderName;
                    dashboardmodel.Code = item.Code;
                    var dashboard = _dashboardService.GetById(item.Id);
                    dashboardmodel.DashboardLists = new List<DashboardLists>();
                    foreach (var items in dashboard)
                    {
                        DashboardLists dashboardList = new DashboardLists();
                        dashboardList.Id = items.Id;
                        dashboardList.Name = items.DashboardSubName;
                        dashboardList.Code = items.Code;
                        dashboardmodel.DashboardLists.Add(dashboardList);
                    }
                    dashboardHeaders.Add(dashboardmodel);
                }
                return dashboardHeaders;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
