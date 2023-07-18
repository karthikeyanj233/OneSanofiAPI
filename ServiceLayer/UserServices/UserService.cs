using DomainLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using ServiceLayer.Model;

namespace ServiceLayer.CustomServices
{
    public class UserService : IUserService<UserModel>
    {
        private readonly IRepository<Users> _userRepository;
        private readonly IConfiguration _config;
        public UserService(IRepository<Users> userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public void Delete(UserModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var model = UserMapping(entity);
                    _userRepository.Delete(model);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public UserModel Get(int Id)
        {
            try
            {
                var obj = _userRepository.Get(Id);
                if (obj != null)
                {
                    var model = UserModelMapping(obj);
                    return model;
                }
                return new UserModel();

            }
            catch (Exception ex) { throw ex; }
        }

        public UserModel GetByEmail(string email)
        {
            try
            {
                var obj = _userRepository.GetByEmail(email);
                UserModel userModel = new UserModel();
                if (obj != null)
                {
                    userModel.Email = email;
                    return userModel;
                }
                return userModel;

            }
            catch (Exception ex) { throw ex; }
        }

        //public ResponseModel Login(UserModel user)
        //{
        //    try
        //    {
        //         ResponseModel model = new ResponseModel();
        //        var loginuser = _userRepository.Login(user.Email, user.Password);
        //        if (loginuser != null)
        //        {
        //            var token = GenerateToken(loginuser.Role);
        //            model.IsSuccess = true;
        //            model.Messsage = token;
        //            model.Role = loginuser.Role;
        //            model.StatusCode = 200;
        //            return model;
        //        }
        //        model.IsSuccess = false;
        //        model.Messsage = "user not found";
        //        return model;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private string GenerateToken(string role)
        //{
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.Role,role)
        //    };
        //    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        //    var tokeOptions = new JwtSecurityToken(issuer: _config["Jwt:Issuer"], audience: _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
        //    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        //    return tokenString;
        //}
        public IEnumerable<UserModel> GetAll()
        {
            try
            {
                var obj = _userRepository.GetAll();
                List<UserModel> userlists = new List<UserModel>();
                if (obj != null)
                {
                    foreach (var item in obj)
                    {
                        var model = UserModelMapping(item);
                        userlists.Add(model);
                    }
                    return userlists;
                }
                return userlists;
            }
            catch (Exception ex) { throw ex; }
        }

        public void Insert(UserModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var model = UserMapping(entity);
                    model.Password = EncodePasswordToBase64(entity.Password);
                    _userRepository.Insert(model);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void Remove(UserModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var model = UserMapping(entity);
                    _userRepository.Remove(model);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void Update(UserModel entity)
        {
            try
            {
                if (entity != null)
                {
                    var model = UserMapping(entity);
                    model.Password = EncodePasswordToBase64(entity.Password);
                    _userRepository.Update(model);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        //this function Convert to Encord your Password
        private static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        private Users UserMapping(UserModel user)
        {
            Users model = new Users();
            model.Id = user.Id;
            model.Name = user.Name;
            //model.FirstName = user.FirstName;
            //model.LastName = user.LastName;
            model.Email = user.Email;
            model.Password = user.Password;
            //model.PhoneNumber = user.PhoneNumber;
            model.Address = user.Address;
            model.City = user.City;
            model.State = user.State;
            model.Country = user.Country;
            return model;
        }
        private UserModel UserModelMapping(Users user)
        {
            UserModel model = new UserModel();
            model.Id = user.Id;
            model.Name = user.Name;
            //model.FirstName = user.FirstName;
            //model.LastName = user.LastName;
            model.Email = user.Email;
            model.Password = user.Password;
            //model.PhoneNumber = user.PhoneNumber;
            model.Address = user.Address;
            model.City = user.City;
            model.State = user.State;
            model.Country = user.Country;
            return model;
        }
    }
}
