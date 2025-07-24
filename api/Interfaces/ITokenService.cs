using System;
using api.Models;

namespace api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        string GenerateRefreshToken();
        string GenerateAccessTokenRefreshToken(string refreshToken, string secret);


    }
}
