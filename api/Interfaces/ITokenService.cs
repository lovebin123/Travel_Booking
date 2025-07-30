using api.Models;
using System;
using System.Security.Claims;

namespace api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
