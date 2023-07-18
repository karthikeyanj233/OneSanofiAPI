using DomainLayer.Models;

namespace ServiceLayer.IDashboardServices
{
    public interface IDashboardHeaderService<T> where T : class
    {
        IEnumerable<T> GetAllDashboard();
    }
}
