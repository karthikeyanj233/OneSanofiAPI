using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.IDashboardServices;
using ServiceLayer.Model;

namespace ServiceLayer.DashboardServices
{
    public class DashboardService : IDashboardService<DashboardModel>
    {
        private readonly IRepository<Dashboard> _dashboardRepository;
        public DashboardService(IRepository<Dashboard> dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public DashboardModel Get(int Id)
        {
            try
            {
                var obj = _dashboardRepository.Get(Id);
                if (obj != null)
                {
                    var model = DashboardModelMapping(obj);
                    return model;
                }
                return new DashboardModel();

            }
            catch (Exception ex) { throw ex; }
        }

        public IEnumerable<DashboardModel> GetAll()
        {
            try
            {
                var obj = _dashboardRepository.GetAll();
                List<DashboardModel> dashboardboxmodel = new List<DashboardModel>();
                if (obj != null)
                {
                    foreach (var item in obj)
                    {
                        var model = DashboardModelMapping(item);
                        dashboardboxmodel.Add(model);
                    }
                    return dashboardboxmodel;
                }
                return dashboardboxmodel;
            }
            catch (Exception ex) { throw ex; }
        }

        public void Insert(DashboardModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var model = DashboardMapping(entity);
                    _dashboardRepository.Insert(model);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void Remove(DashboardModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var model = DashboardMapping(entity);
                    _dashboardRepository.Remove(model);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void Update(DashboardModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var model = DashboardMapping(entity);
                    _dashboardRepository.Update(model);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void Delete(DashboardModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var model = DashboardMapping(entity);
                    _dashboardRepository.Delete(model);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public IEnumerable<DashboardModel> GetAllDashboard()
        {
            try
            {
                List<DashboardModel> dashboardHeaders = new List<DashboardModel>();
                var obj = _dashboardRepository.GetAll();
                if (obj != null)
                {
                    foreach (var item in obj)
                    {
                        var model = DashboardModelMapping(item);
                        dashboardHeaders.Add(model);
                    }
                    return dashboardHeaders;
                }
                return dashboardHeaders;
            }
            catch (Exception ex) { throw ex; }
        }
        private Dashboard DashboardMapping(DashboardModel dashboard)
        {
            Dashboard model = new Dashboard();
            model.Id = dashboard.Id;
            model.DashboardSubName = dashboard.DashboardSubName;
            model.Description = dashboard.Description;
            model.ExpireDate = dashboard.ExpireDate;
            model.Code = dashboard.Code;
            return model;
        }
        private DashboardModel DashboardModelMapping(Dashboard dashboard)
        {
            DashboardModel model = new DashboardModel();
            model.Id = dashboard.Id;
            model.DashboardSubName = dashboard.DashboardSubName;
            model.Description = dashboard.Description;
            model.ExpireDate = dashboard.ExpireDate;
            model.Code = dashboard.Code;
            return model;

        }
    }
}
