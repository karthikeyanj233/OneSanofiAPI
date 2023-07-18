using DomainLayer.Models;

namespace RepositoryLayer.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
        Users Login(string Email, string Password);
        IEnumerable<UserRoles> GetByIdAll(int Id);
        IEnumerable<RolePages> GetByIdRolePagesAll(int Id);
        IEnumerable<Dashboard> GetById(int Id);
        Users GetByEmail(string email);
    }
}
