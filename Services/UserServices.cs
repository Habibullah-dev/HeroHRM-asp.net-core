using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeroHRM.Services
{
    public class UserServices : IUserServices
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserServices(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
