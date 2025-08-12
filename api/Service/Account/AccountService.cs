using api.DTO.Account;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613,8604
namespace api.Service.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContext;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService,
            IConfiguration config, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _config = config;
            _httpContext = httpContext;
        }
        public async Task<IActionResult> SignUp(SignUpDto signUpDTO)
        {
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
                return new ObjectResult(createdUser.Errors) { StatusCode = 500 };
            }
            Log.Information("Successfully created account");
            var role = user.Email == "admin@gmail.com" ? "Admin" : "User";
            var roleResult = await _userManager.AddToRoleAsync(user, role);

            if (!roleResult.Succeeded)
            {
                Log.Error("Failed to assign role");
                return new ObjectResult(roleResult.Errors) { StatusCode = 500 };
            }
            Log.Information("Successfully signed up");
            return new OkObjectResult(new NewUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Role = role,
                RefreshToken = _tokenService.GenerateRefreshToken(),
            });
        }
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.Email.ToLower());
            if (user == null)
            {
                Log.Error("Invalid Username");
                return new UnauthorizedObjectResult("Invalid username");
            }

            var result = await _signinManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, true, false);
            if (!result.Succeeded)
            {
                Log.Error("Invalid Credentials");
                return new UnauthorizedObjectResult("Invalid credentials");
            }
            var role = user.Email == "admin@gmail.com" ? "Admin" : "User";
            await _userManager.AddToRoleAsync(user, role);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);
            Log.Information("Successfully logged in");
            return new OkObjectResult(new NewUserDto
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

        public async Task<IActionResult> VerifyEmail(VerifyEmailDTO dto)
        {

            var user = await _userManager.FindByNameAsync(dto.Email);
            if (user == null) return new UnauthorizedObjectResult("Email does not exist");
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_ID");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("travelvoyage@maildrop.cc", "Book Voyage");
            var to = new EmailAddress(user.Email);
            var token = _tokenService.CreateToken(user);
            var rnd = new Random();
            int verificationCode = rnd.Next(1000000, 8000000);
            string verCode = verificationCode.ToString();
            _httpContext.HttpContext.Response.Cookies.Append(
                "verificationCode",
                verCode,
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
            if (response.IsSuccessStatusCode)
            {

                return new OkObjectResult(new { username = dto.Email });
            }
            else
            {
                return new ObjectResult("Failed to send Email") { StatusCode = (int)response.StatusCode };
            }
        }

        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
        {
            var verificationCode = _httpContext.HttpContext.Request.Cookies["verificationCode"];
            if(verificationCode.CompareTo(dto.verificationCode)!=0)
            {
                return new UnauthorizedObjectResult("Invalud Verification Code");
            }
            var user = await _userManager.FindByNameAsync(dto.Email);
            if (user == null) return new UnauthorizedObjectResult("User does not exist");
            var result = await _userManager.RemovePasswordAsync(user);
            if (!result.Succeeded) return new UnauthorizedObjectResult("Failed to change password");

            result = await _userManager.AddPasswordAsync(user, dto.Password);
            return result.Succeeded
                ? new OkObjectResult(new { message = "Password changed successfully" })
                : new UnauthorizedObjectResult("Password change failed");
        }

        public async Task<IActionResult> GetUserName(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return user == null ? new UnauthorizedResult() : new OkObjectResult(user);
        }

        public async Task<IActionResult> GetUserDetails(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return new OkObjectResult(new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber
            });
        }

        public async Task<IActionResult> EditUserDetails(string username, editUserDto dto)
        {
            var user = await _userManager.FindByNameAsync(username);
            user.FirstName = dto.firstName;
            user.LastName = dto.lastName;
            user.Email = dto.email;
            user.PhoneNumber = dto.phoneNumber;
            await _userManager.UpdateAsync(user);
            return new OkObjectResult(new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber
            });
        }

        public async Task<IActionResult> RefreshPage(TokenResponseDto tokenResponse)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(tokenResponse.AccessToken);
            var username = principal.GetFirstName();
            var user = await _userManager.FindByNameAsync(username);

            var newToken = _tokenService.CreateToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return new OkObjectResult(new NewUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = newToken,
                RefreshToken = newRefreshToken
            });
        }

        private bool ValidateModel(object model) => model != null;
    }
}
