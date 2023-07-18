using DomainLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Model;
using ServiceLayer.ILoginServices;
using ServiceLayer.Model;
using System.Security.Claims;

namespace OneSanofi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService<LoginModel> _loginService;

        public LoginController(ILoginService<LoginModel> loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        [HttpPost(nameof(Login))]
        public IActionResult Login(LoginModel user)
        {
            try
            {
                var userRoles = _loginService.Login(user);
                if (userRoles.IsSuccess == false)
                {
                    _logger.LogWarning("User not found");
                    return NotFound();
                }
                else
                {
                    //Save token in session object
                    HttpContext.Session.SetString("JWToken", userRoles.Messsage);
                    List<Claim> userClaims = new List<Claim>();
                    userClaims.Add(new Claim("UserName", user.Email));
                    userClaims.Add(new Claim(ClaimTypes.Name, user.Email));
                    userClaims.Add(new Claim(ClaimTypes.Email, user.Email));
                    if (userRoles.Role != null)
                        userClaims.Add(new Claim(ClaimTypes.Role, userRoles.Role));
                    else
                        userClaims.Add(new Claim(ClaimTypes.Role, "Null"));
                    foreach (var userRole in userRoles.RolesModels)
                    {
                        userClaims.Add(new Claim("roles", userRole.RoleName));
                    }

                    
                    //    var userClaims = new List<Claim>()
                    //{
                    //    new Claim("UserName", user.Email),
                    //    new Claim(ClaimTypes.Name, user.Email),
                    //    new Claim(ClaimTypes.Email, user.Email),
                    //    new Claim(ClaimTypes.Role, userRoles.Role),
                    //    //new Claim(ClaimTypes.Role, obj.Role)
                    // };
                    //foreach (var userRole in userRoles.RolesModels)
                    //{
                    //    userClaims.Append(new Claim("roles", userRole.RoleName));
                    //}

                    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                    HttpContext.SignInAsync(userPrincipal);
                    _logger.LogInformation("Login Successfully");
                    return Ok(userRoles);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Login error: " + ex.Message);
                throw ex;
            }

        }

        [HttpPost(nameof(Logoff))]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("https://localhost:7032/swagger/index.html");
        }
    }
}
