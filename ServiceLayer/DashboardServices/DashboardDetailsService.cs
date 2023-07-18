using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.IDashboardServices;
using ServiceLayer.Model;

namespace ServiceLayer.DashboardServices
{
    public class DashboardDetailsService : IDashboardService<DashboardDetailModel>
    {
        private readonly IRepository<Dashboard_Details> _dashboardRepository;
        public DashboardDetailsService(IRepository<Dashboard_Details> dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public DashboardDetailModel Get(int Id)
        {
            try
            {
                var obj = _dashboardRepository.Get(Id);
                if (obj != null)
                {
                    var modal = DashboardDetailModelMapping(obj);
                    return modal;
                }
                return new DashboardDetailModel();
            }
            catch (Exception ex) { throw ex; }
        }
        public IEnumerable<DashboardDetailModel> GetAll()
        {
            try
            {
                var obj = _dashboardRepository.GetAll();
                List<DashboardDetailModel> dashboardDetailModel = new List<DashboardDetailModel>();
                if (obj != null)
                {
                    foreach (var item in obj)
                    {
                        var modal = DashboardDetailModelMapping(item);
                        dashboardDetailModel.Add(modal);
                    }
                    return dashboardDetailModel;
                }
                return dashboardDetailModel;
            }
            catch (Exception ex) { throw ex; }
        }

        public void Insert(DashboardDetailModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var modal = DashboardDetailMapping(entity);
                    _dashboardRepository.Insert(modal);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void Remove(DashboardDetailModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var modal = DashboardDetailMapping(entity);
                    _dashboardRepository.Remove(modal);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void Update(DashboardDetailModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var modal = DashboardDetailMapping(entity);
                    _dashboardRepository.Update(modal);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void Delete(DashboardDetailModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var modal = DashboardDetailMapping(entity);
                    _dashboardRepository.Delete(modal);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public IEnumerable<DashboardDetailModel> GetAllDashboard()
        {
            try
            {
                List<DashboardDetailModel> dashboardHeaders = new List<DashboardDetailModel>();
                var obj = _dashboardRepository.GetAll();
                if (obj != null)
                {
                    foreach (var item in obj)
                    {
                        var modal = DashboardDetailModelMapping(item);
                        dashboardHeaders.Add(modal);
                    }
                    return dashboardHeaders;
                }
                return dashboardHeaders;
            }
            catch (Exception ex) { throw ex; }
        }
        private Dashboard_Details DashboardDetailMapping(DashboardDetailModel dashboardDetail)
        {
            Dashboard_Details model = new Dashboard_Details();
            model.Id = dashboardDetail.Id;
            model.Dashboard_Html = dashboardDetail.Dashboard_Html;
            model.Description = dashboardDetail.Description;
            model.ExpireDate = dashboardDetail.ExpireDate;
            model.Code = dashboardDetail.Code;
            return model;
        }
        private DashboardDetailModel DashboardDetailModelMapping(Dashboard_Details dashboardDetail)
        {
            DashboardDetailModel model = new DashboardDetailModel();
            model.Id = -dashboardDetail.Id;
            model.Dashboard_Html = dashboardDetail.Dashboard_Html;
            model.Description = dashboardDetail.Description;
            model.ExpireDate = dashboardDetail.ExpireDate;
            model.Code = dashboardDetail.Code;
            return model;

        }
    }
}
