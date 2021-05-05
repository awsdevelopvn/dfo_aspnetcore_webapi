using System.Security.Claims;
using DFO_Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DFO_aspnetcore_api.Services
{
    public class AuthenticatedUserService: IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        }

        public string UserId { get; }
    }
}