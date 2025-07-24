using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using EllipticCurve.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace api.Service
{
    public class TokenService:ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<AppUser> _userManager;
        public TokenService(IConfiguration config,UserManager<AppUser>userManager)
        {
            _config = config;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public string CreateToken(AppUser user)
        {
            var claims=new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName,user.UserName),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            var roles =  _userManager.GetRolesAsync(user).GetAwaiter().GetResult();
            foreach (var userRole in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var creds=new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);
            var descriptor=new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(claims),
                Expires=DateTime.Now.AddMinutes(15),
                 
                SigningCredentials =creds,
                Issuer=_config["JWT:Issuer"],
                Audience=_config["JWT:Audience"]
            };
            var tokenHandler=new JwtSecurityTokenHandler();
            var token=tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);

        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng=RandomNumberGenerator.Create();
            Console.WriteLine(rng);
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);

        }
        public string GenerateAccessTokenRefreshToken(string refreshToken,string secret)
        {
            var tokenHandler=new JwtSecurityTokenHandler();
            var key=Encoding.ASCII.GetBytes(secret);
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var descriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddMinutes(15),
                SigningCredentials = creds
            };
            var token=tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
