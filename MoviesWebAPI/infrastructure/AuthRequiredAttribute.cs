using DAL.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace ProductWebAPI.Infrastructure {
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {

        }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizations);

            string token = authorizations.SingleOrDefault(auth => auth.StartsWith("Bearer "));
            TokenService tokenService = (TokenService)context.HttpContext.RequestServices.GetService(typeof(TokenService));

            if (token is null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            Customer c = tokenService.VerifyToken(token);

            if (c is null)
                context.Result = new UnauthorizedResult();
            
        }
    }
}
