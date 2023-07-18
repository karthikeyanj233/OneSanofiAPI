using DomainLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.IRepository;
using RepositoryLayer.Model;
using ServiceLayer.ILoginServices;
using ServiceLayer.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceLayer.LoginServices
{
    public class LoginService : ILoginService<LoginModel>
    {
        private readonly IRepository<Users> _loginRepository;
        private readonly IRepository<UserRoles> _userroleRepository;
        private readonly IRepository<Roles> _roleRepository;
        private readonly IRepository<RolePages> _rolepageRepository;
        private readonly IRepository<Pages> _pageRepository;
        private readonly IConfiguration _config;
        public LoginService(IRepository<Users> loginRepository, IConfiguration config, IRepository<UserRoles> userroleRepository, IRepository<Roles> roleRepository, IRepository<RolePages> rolepageRepository, IRepository<Pages> pageRepository)
        {
            _loginRepository = loginRepository;
            _config = config;
            _userroleRepository = userroleRepository;
            _roleRepository = roleRepository;
            _rolepageRepository = rolepageRepository;
            _pageRepository = pageRepository;
        }

        //public IEnumerable<UserRoles> Get(int Id)
        //{
        //    try
        //    {
        //        var obj = _userroleRepository.GetByIdAll(Id);
        //        if (obj != null)
        //        {
        //            return obj;
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
        //}
        public ResponseModel Login(LoginModel user)
        {
            try
            {
                ResponseModel model = new ResponseModel();
                var password = EncodePasswordToBase64(user.Password);
                var loginuser = _loginRepository.Login(user.Email, password);
                if (loginuser != null)
                {
                    model.RolesModels = new List<RolesModel>();
                    model.PagesModels = new List<PagesModel>();
                    var roleslists = _userroleRepository.GetByIdAll(loginuser.Id);
                    foreach (var item in roleslists)
                    {
                        var roleslist = _roleRepository.Get(item.Role_Id);
                        if (roleslist !=null)
                        {
                            RolesModel role = new RolesModel();
                            role.RoleId = roleslist.Id;
                            role.RoleName = roleslist.RoleName;
                            model.Role = roleslist.RoleName;
                            model.RolesModels.Add(role);
                        }
                        var rolepagelist = _rolepageRepository.GetByIdRolePagesAll(item.Role_Id);
                        if (rolepagelist.Count() > 0)
                        {
                            foreach (var items in rolepagelist)
                            {
                                var rolepage = _pageRepository.Get(items.Page_Id);
                                PagesModel pagesModel = new PagesModel();
                                pagesModel.PageId = rolepage.Id;
                                pagesModel.PageMenu = rolepage.PageName;
                                model.PagesModels.Add(pagesModel);
                            }
                        }
                    }
                    var token = GenerateToken(model);
                    model.IsSuccess = true;
                    model.Messsage = token;
                    model.Role = model.Role;
                    model.Id = loginuser.Id.ToString();
                    model.StatusCode = 200;
                    
                    return model;
                }
                model.IsSuccess = false;
                model.Messsage = "user not found";
                return model;

            }
            catch (Exception ex) { throw ex; }
        }
        private string GenerateToken(ResponseModel model)
        {
            List<Claim> claims = new List<Claim>();
            if(model.Role !=null)
                claims.Add(new Claim(ClaimTypes.Role, model.Role));
            else
                claims.Add(new Claim(ClaimTypes.Role, "Null"));
            foreach (var item in model.RolesModels)
            {
                claims.Add(new Claim("RoleList", item.RoleName));
            }
            foreach (var item in model.PagesModels)
            {
                claims.Add(new Claim("Menu", item.PageMenu));
            }

            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Role,user.Role),
            //    new Claim("RoleList",model.RolesModels.)
            //};
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(issuer: _config["Jwt:Issuer"], audience: _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
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
        //this function Convert to Decord your Password
        private string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        //private string GenerateRole(User user)
        //{
        //    var userClaims = new List<Claim>()
        //        {
        //            new Claim("UserName", user.Name),
        //            new Claim(ClaimTypes.Name, user.Name),
        //            new Claim(ClaimTypes.Email, user.Email),
        //            new Claim(ClaimTypes.Role, user.Country)
        //         };

        //    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

        //    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
        //    HttpContext.SignInAsync(userPrincipal);

        //}
    }
}
