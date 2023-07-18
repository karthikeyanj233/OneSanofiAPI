using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;
using ServiceLayer.Model;

namespace OneSanofi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService<UserModel> _userService;
        public UserController(IUserService<UserModel> userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet(nameof(GetUserById))]
        public IActionResult GetUserById(int Id)
        {
            try
            {
                var obj = _userService.Get(Id);
                if (obj != null)
                {
                    _logger.LogInformation("Successfullly got user list");
                    return Ok(obj);
                }
                _logger.LogWarning("Record not found");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("GetUserById error: " + ex.Message);
                throw ex;
            }
        }

        //[AllowAnonymous]
        //[HttpPost(nameof(Login))]
        //public IActionResult Login(Users user)
        //{
        //    try
        //    {
        //        var obj = _userService.Login(user);
        //        if (obj == null)
        //        {
        //            _logger.LogWarning("User not found");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            //Save token in session object
        //            HttpContext.Session.SetString("JWToken", obj.Messsage);
        //            var userClaims = new List<Claim>()
        //        {
        //            new Claim("UserName", user.Email),
        //            new Claim(ClaimTypes.Name, user.Email),
        //            new Claim(ClaimTypes.Email, user.Email),
        //            new Claim(ClaimTypes.Role, obj.Role)
        //         };

        //            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

        //            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
        //            HttpContext.SignInAsync(userPrincipal);
        //            _logger.LogInformation("Login Successfully");
        //            return Ok(obj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Login error: " + ex.Message);
        //        throw ex;
        //    }
            
        //}

        
        [HttpGet(nameof(GetAllUser))]
        public IActionResult GetAllUser()
        {
            try
            {
                var obj = _userService.GetAll();
                if (obj == null)
                {
                    _logger.LogWarning("Record not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("GetAllUser Information");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllUser error: " + ex.Message);
                throw ex;
            }
            
        }

        [AllowAnonymous]
        [HttpPost(nameof(CreateUser))]
        public IActionResult CreateUser(UserModel user)
        {
            try
            {
                if (user != null)
                {
                    var verifyemail = _userService.GetByEmail(user.Email);
                    if (verifyemail.Email == null)
                    {
                        _userService.Insert(user);
                        _logger.LogInformation("Created Successfully");
                        return Ok("Created Successfully");
                    }
                    _logger.LogInformation("Email address already exists.");
                    return NotFound("Email address already exists.");
                }
                _logger.LogWarning("Somethingwent wrong");
                return BadRequest("Somethingwent wrong");
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateUser error: " + ex.Message);
                throw ex;
            }
        }

        [HttpPost(nameof(UpdateUser))]
        public IActionResult UpdateUser(UserModel user)
        {
            try
            {
                if (user != null)
                {
                    _userService.Update(user);
                    _logger.LogInformation("Updated Successfully");
                    return Ok("Updated SuccessFully");
                }
                _logger.LogWarning("Somethingwent wrong");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateUser error: " + ex.Message);
                throw ex;
            }
        }

        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(UserModel user)
        {
            try
            {
                if (user != null)
                {
                    _userService.Delete(user);
                    _logger.LogInformation("Deleted Successfully");
                    return Ok("Deleted Successfully");
                }
                _logger.LogWarning("DeleteUser Something went wrong");
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteUser error: " + ex.Message);
                throw ex;
            }
        }

        //[HttpPost(nameof(Logoff))]
        //public IActionResult Logoff()
        //{
        //    HttpContext.Session.Clear();
        //    return Redirect("https://localhost:7032/swagger/index.html");
        //}
    }
}
