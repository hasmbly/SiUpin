using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Constants;

namespace SiUpin.WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public bool IsAuthenticated { get; }
        public string Username { get; }
        public string PictureURL { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            Username = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            PictureURL = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimType.PictureUrl);
            IsAuthenticated = Username != null;
        }
    }
}