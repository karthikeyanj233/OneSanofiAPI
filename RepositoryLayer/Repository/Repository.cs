using DomainLayer.Data;
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region property
        private readonly OneSanofiDbContext _oneSanofiDbContext;
        private DbSet<T> entities;
        #endregion

        #region Constructor
        public Repository(OneSanofiDbContext oneSanofiDbContext)
        {
            _oneSanofiDbContext = oneSanofiDbContext;
            entities = _oneSanofiDbContext.Set<T>();
        }
        #endregion

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _oneSanofiDbContext.SaveChanges();
        }

        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public Users GetByEmail(string email)
        {
            return _oneSanofiDbContext.Users.FirstOrDefault(c => c.Email == email);
        }

        public IEnumerable<UserRoles> GetByIdAll(int Id)
        {
            return _oneSanofiDbContext.UserRoles.Where(c => c.User_Id == Id);
        }

        public IEnumerable<RolePages> GetByIdRolePagesAll(int Id)
        {
            return _oneSanofiDbContext.RolePages.Where(c => c.Role_Id == Id);
        }

        public Users Login(string Email, string Password)
        {
            return _oneSanofiDbContext.Users.FirstOrDefault(c => c.Email == Email && c.Password == Password);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _oneSanofiDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _oneSanofiDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _oneSanofiDbContext.SaveChanges();
        }

        public IEnumerable<Dashboard> GetById(int Id)
        {
            return _oneSanofiDbContext.Dashboard.Where(c => c.Dashboard_BoxId == Id);
        }
    }
}
