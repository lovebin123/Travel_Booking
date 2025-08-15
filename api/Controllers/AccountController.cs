using api.DTO.Account;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Asp.Versioning;
using AutoWrapper.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContext;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signinManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService,
            IConfiguration config,
            IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _config = config;
            _httpContext = httpContext;
        }

        [HttpPost("signup")]
        [ProducesResponseType(typeof(NewUserDto), StatusCodes.Status200OK)]
        [AutoWrapIgnore(ShouldLogRequestData = false)]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(signUpDTO.email);
            if (existingUser != null)
            {
                Log.Warning("Attempt to sign up with existing email: {Email}", signUpDTO.email);
                return BadRequest(new { message = "User already exists" });
            }

            var user = new AppUser
            {
                FirstName = signUpDTO.firstName,
                LastName = signUpDTO.lastName,
                UserName = signUpDTO.email,
                Email = signUpDTO.email
            };

            var createdUser = await _userManager.CreateAsync(user, signUpDTO.password);
            if (!createdUser.Succeeded)
            {
                Log.Error("Failed to create account");
                return StatusCode(500, createdUser.Errors);
            }

            var role = user.Email == "admin@gmail.com" ? "Admin" : "User";
            var roleResult = await _userManager.AddToRoleAsync(user, role);
            if (!roleResult.Succeeded)
            {
                Log.Error("Failed to assign role");
                return StatusCode(500, roleResult.Errors);
            }

            return Ok(new NewUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Role = role,
                RefreshToken = _tokenService.GenerateRefreshToken()
            });
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(NewUserDto), StatusCodes.Status200OK)]
        [AutoWrapIgnore(ShouldLogRequestData = false)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDTO)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.Email.ToLower());
            if (user == null)
            {
                Log.Error("Invalid Username");
                return Unauthorized("Invalid username");
            }

            var result = await _signinManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, true, false);
            if (!result.Succeeded)
            {
                Log.Error("Invalid Credentials");
                return Unauthorized("Invalid credentials");
            }

            var role = user.Email == "admin@gmail.com" ? "Admin" : "User";
            await _userManager.AddToRoleAsync(user, role);

            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return Ok(new NewUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Role = role,
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = user.RefreshTokenExpiryTime.Value
            });
        }

        [HttpPost("verifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailDTO dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Email);
            if (user == null) return Unauthorized("Email does not exist");

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_ID");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("travelvoyage@maildrop.cc", "Book Voyage");
            var to = new EmailAddress(user.Email);
            var token = _tokenService.CreateToken(user);
            var rnd = new Random();
            int verificationCode = rnd.Next(1000000, 8000000);

            _httpContext.HttpContext.Response.Cookies.Append(
                "verificationCode",
                verificationCode.ToString(),
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(10),
                    Path = "/"
                }
            );

            var link = $"http://localhost:4200/auth/forgotPassword/{token}";
            var htmlContent = $"<strong>Click to reset:</strong><br/><a href=\"{link}\">{link}</a><br/><center>Your verification code is:{verificationCode}</center>";
            var msg = MailHelper.CreateSingleEmail(from, to, "Password reset mail", link, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode
                ? Ok(new { username = dto.Email })
                : StatusCode((int)response.StatusCode, "Failed to send Email");
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var verificationCode = _httpContext.HttpContext.Request.Cookies["verificationCode"];
            if (verificationCode != dto.verificationCode)
            {
                return Unauthorized("Invalid Verification Code");
            }

            var user = await _userManager.FindByNameAsync(dto.Email);
            if (user == null) return Unauthorized("User does not exist");

            var result = await _userManager.RemovePasswordAsync(user);
            if (!result.Succeeded) return Unauthorized("Failed to change password");

            result = await _userManager.AddPasswordAsync(user, dto.Password);
            return result.Succeeded
                ? Ok(new { message = "Password changed successfully" })
                : Unauthorized("Password change failed");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getUserName")]
        public async Task<IActionResult> GetUserName([FromQuery] string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return user == null ? Unauthorized() : Ok(user);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("userDetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            var user = await _userManager.FindByNameAsync(User.GetFirstName());
            return Ok(new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber
            });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("editDetails")]
        public async Task<IActionResult> EditUserDetails([FromBody] editUserDto dto)
        {
            var user = await _userManager.FindByNameAsync(User.GetFirstName());
            user.FirstName = dto.firstName;
            user.LastName = dto.lastName;
            user.Email = dto.email;
            user.PhoneNumber = dto.phoneNumber;
            await _userManager.UpdateAsync(user);

            return Ok(new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshPage([FromBody] TokenResponseDto tokenResponse)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(tokenResponse.AccessToken);
            var username = principal.GetFirstName();
            var user = await _userManager.FindByNameAsync(username);

            var newToken = _tokenService.CreateToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return Ok(new NewUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = newToken,
                RefreshToken = newRefreshToken
            });
        }
    }
}
