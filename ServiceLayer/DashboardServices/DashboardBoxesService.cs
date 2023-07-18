using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.IDashboardServices;
using ServiceLayer.Model;

namespace ServiceLayer.DashboardServices
{
    public class DashboardBoxesService : IDashboardService<DashboardBoxModel>
    {
        private readonly IRepository<Dashboard_Boxes> _dashboardRepository;

        public DashboardBoxesService(IRepository<Dashboard_Boxes> dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public DashboardBoxModel Get(int Id)
        {
            try
            {
                var obj = _dashboardRepository.Get(Id);
                if (obj != null)
                {
                    var mode = DashboardModelMapping(obj);
                    return mode;
                }
                return new DashboardBoxModel();

            }
            catch (Exception ex) { throw ex; }
        }

        public IEnumerable<DashboardBoxModel> GetAll()
        {
            try
            {
                var obj = _dashboardRepository.GetAll();
                List<DashboardBoxModel> dashboardboxmodel = new List<DashboardBoxModel>();
                if (obj != null)
                {
                    foreach (var item in obj)
                    {
                        var mode = DashboardModelMapping(item);
                        dashboardboxmodel.Add(mode);
                    }
                    return dashboardboxmodel;
                }
                return dashboardboxmodel;
            }
            catch (Exception ex) { throw ex; }
        }

        public void Insert(DashboardBoxModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var mode = DashboardMapping(entity);
                    _dashboardRepository.Insert(mode);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void Remove(DashboardBoxModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var mode = DashboardMapping(entity);
                    _dashboardRepository.Remove(mode);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void Update(DashboardBoxModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var mode = DashboardMapping(entity);
                    _dashboardRepository.Update(mode);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void Delete(DashboardBoxModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var mode = DashboardMapping(entity);
                    _dashboardRepository.Delete(mode);
                    _dashboardRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public IEnumerable<DashboardBoxModel> GetAllDashboard()
        {
            List<DashboardBoxModel> dashboardboxmodel = new List<DashboardBoxModel>();
            var obj = _dashboardRepository.GetAll();
            if (obj != null)
            {
                var sdfdsdf = obj.FirstOrDefault();
                foreach (var item in obj)
                {
                    var mode = DashboardModelMapping(item);
                    dashboardboxmodel.Add(mode);
                }
                return dashboardboxmodel;
            }
            return dashboardboxmodel;
        }

        private Dashboard_Boxes DashboardMapping(DashboardBoxModel dashboardBoxes)
        {
            Dashboard_Boxes model = new Dashboard_Boxes();
            model.Id = dashboardBoxes.Id;
            model.DashboardHeaderName = dashboardBoxes.DashboardHeaderName;
            model.Description = dashboardBoxes.Description;
            model.ExpireDate = dashboardBoxes.ExpireDate;
            model.Code = dashboardBoxes.Code;
            return model;
        }
        private DashboardBoxModel DashboardModelMapping(Dashboard_Boxes dashboardBoxes)
        {
            DashboardBoxModel model = new DashboardBoxModel();
            model.Id = dashboardBoxes.Id;
            model.DashboardHeaderName = dashboardBoxes.DashboardHeaderName;
            model.Description = dashboardBoxes.Description;
            model.ExpireDate = dashboardBoxes.ExpireDate;
            model.Code = dashboardBoxes.Code;
            return model;

        }
        //public IEnumerable<DashboardHeader> GetAllDashboard()
        //{
        //    try
        //    {
        //        IEnumerable<DashboardHeader> dashboardHeaders = new List<DashboardHeader>();
        //        var dsshboardbox = _dashboardRepository.GetAll();
        //        //var sdfdsdf = obj.FirstOrDefault();
        //        foreach ( var item in dsshboardbox) {
        //            DashboardHeader dashboardmodel = new DashboardHeader();
        //            dashboardmodel.Id = item.Id;
        //            dashboardmodel.HeaderName = item.Title;
        //            dashboardmodel.Code = item.Code;
        //            var dashboard = _dashboardRepository.Get(item.Id);
        //            if (dashboard != null)
        //            {
        //                //DashboardLists dashboardList = new DashboardLists();
        //               var dashboardList = dashboardmodel.DashboardLists.FirstOrDefault();
        //                dashboardList.Id = dashboard.Id;
        //                dashboardList.Name = dashboard.Title;
        //                dashboardList.Code = dashboard.Code;
        //            }
        //            dashboardHeaders.Append(dashboardmodel);
        //            //var sdsd = item.Title;
        //        }
        //        //dashboardHeaders.Append(obj);
        //        if (dashboardHeaders != null)
        //        {
        //            return dashboardHeaders;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
    }
}
