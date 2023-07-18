using RepositoryLayer.Model;
using ServiceLayer.Model;

namespace ServiceLayer.ILoginServices
{
    public interface ILoginService<T> where T : class
    {
        ResponseModel Login(LoginModel user);
    }
}
