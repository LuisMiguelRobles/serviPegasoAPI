﻿namespace Infrastructure.Security
{
    using Application.Interfaces;
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Http;

    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUsername()
        {
            var username = _httpContextAccessor.HttpContext.User?.Claims
                ?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return username;
        }
    }
}
