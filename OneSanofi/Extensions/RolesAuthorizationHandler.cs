
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace OneSanofi.Extensions
{
    //public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationRequirement
    {
        //private readonly IUserService<Roles> _roleService;
        //protected override void Handle(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        //{
        //    var roles = new[] { "Admin", "Admin2", "Admin3" };  //Get From DB.
        //    var userIsInRole = roles.Any(role => context.User.IsInRole(role));
        //    if (!userIsInRole)
        //    {
        //        context.Fail();
        //        return;
        //    }

        //    context.Succeed(requirement);
        //}
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       RolesAuthorizationRequirement requirement)
        {
            var mvcContext = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;

            //var roles = new[] { "Admin", "Admin2", "Admin3" };  //Get From DB.
            //var userIsInRole = roles.Any(role => context.User.IsInRole(role));
            var value = "";
            if (context.Resource is HttpContext httpContext)
            {
                value = httpContext.Request.Path.Value;
            }
            var words = value.Split('/');
            var controlpage = words[2];
            var userIsInMenu = context.User.Claims.Where(x => x.Type == "Menu");
            var userIsInRole = userIsInMenu.Any(menu => menu.Value == controlpage);
            if (!userIsInRole)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);

            //if (context.User == null || !context.User.Identity.IsAuthenticated)
            //{
            //    context.Fail();
            //    return Task.CompletedTask;
            //}

            //var validRole = false;
            //if (requirement.AllowedRoles == null ||
            //    requirement.AllowedRoles.Any() == false)
            //{
            //    validRole = true;
            //}
            //else
            //{
            //    var claims = context.User.Claims;
            //    var roles = requirement.AllowedRoles;
            //    var roleauth = requirement.AllowedRoles.FirstOrDefault();
            //    var rolecheck = claims.FirstOrDefault(c => c.Value == roleauth);

            //    if (rolecheck != null)
            //        validRole = true;
            //    else
            //        validRole = false;
            //    //validRole = new Users().GetUsers().Where(p => roles.Contains(p.Role) && p.UserName == userName).Any();
            //}

            //if (validRole)
            //{
            //    context.Succeed(requirement);
            //}
            //else
            //{
            //    context.Fail();
            //}
            return Task.CompletedTask;
        }
    }
}
