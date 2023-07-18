
namespace ServiceLayer.ICustomServices
{
    public interface IUserService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        T GetByEmail(string email);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        //ResponseModel Login(UserModel user);
    }
}
