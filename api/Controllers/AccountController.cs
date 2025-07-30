using System;
using api.DTO.Account;
using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Service;
using DotNetEnv;
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
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AppUser> _logger;
        private readonly IConfiguration _config;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, ILogger<AppUser> logger,IConfiguration config)
        {
            Env.Load();
            _config = config;
            _userManager = userManager;
            _signinManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_ID");
            var client = new SendGridClient(apiKey);
            _logger = logger;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO signUpDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = new AppUser
                {
                    FirstName = signUpDTO.firstName,
                    LastName = signUpDTO.lastName,
                    UserName = signUpDTO.email,
                    Email = signUpDTO.email
                };
                var createdUser = await _userManager.CreateAsync(user, signUpDTO.password);
                if (createdUser.Succeeded)
                {
                    Log.Information("User created successfully");
                    var role = user.Email == "admin@gmail.com" ? "Admin" : "User";
                    var roleResult = await _userManager.AddToRoleAsync(user, role);
                    if (roleResult.Succeeded)
                    {
                        Log.Information("Role assigned successfully");
                        return Ok(
                            new NewUserDTO
                            {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user),
                                Role = role,
                                RefreshToken = _tokenService.GenerateRefreshToken(),
                            }
                        );
                    }
                    else
                    {
                    Log.Error("User creation failed");
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    Log.Error("Error");
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception e)
            {
               Log.Error("Catch block error");
                return StatusCode(500, e);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.Users.FirstOrDefaultAsync(x => string.Compare(x.UserName, loginDTO.Email.ToLower()) == 0);
            if (user == null)
            {
                Log.Error("Invalid username");
                return Unauthorized("Invalid username");
            }
            var result = await _signinManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: true, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                Log.Error("Invalid credentials");
                return Unauthorized("Invalid credentials");
            }
            var role = user.Email == "admin@gmail.com" ? "Admin" : "User";
            var roleResult = await _userManager.AddToRoleAsync(user, role);
            var accessToken = _tokenService.CreateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);
            return Ok(new NewUserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Role = role,
                RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(5),
                RefreshToken=refreshToken

            });
        }

        [HttpPost("verifyEmail")]
        public async Task<IActionResult> VerifyEmail(VerifyEmailDTO verifyEmailDTO)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_ID");
            var client = new SendGridClient(apiKey);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByNameAsync(verifyEmailDTO.Email);
            if (user == null)
            {
                Log.Error("Email does not exist");
                return Unauthorized("Email does not exist");
            }
            var from = new EmailAddress("bookvoyage@maildrop.cc", "Book Voyage");
            var to = new EmailAddress(user.Email);
            var token = _tokenService.CreateToken(user);
            Console.WriteLine(token);
            var link = $"http://localhost:4200/forgotPassword/{token}";
            var htmlContent = $"<strong>Click the link below to reset your password:</strong><br/><a href=\"{link}\">{link}</a>";
            var subject = "Password reset mail";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, link, htmlContent);
            var response = await client.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                Log.Error("Email successfully sent");
                return Ok(new { username = verifyEmailDTO.Email });
            }
            else
            {
                Log.Error("Failed to send email");
                return StatusCode((int)response.StatusCode, "Failed to send email");
            }
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByNameAsync(forgotPasswordDTO.Email);
            if (user == null)
            {
                Log.Error("User does not exist");
                return Unauthorized("User does not exist");
            }
            var result = await _userManager.RemovePasswordAsync(user);
            if (!result.Succeeded)
            {
                Log.Error("Failed to change password");
                return Unauthorized("Failed to change password");
            }
            result = await _userManager.AddPasswordAsync(user, forgotPasswordDTO.Password);
            if (!result.Succeeded)
            {
                Log.Error("Password change failed");
                return Unauthorized("Password change failed");
            }
            Log.Information("Password change was successful");
            return Ok(new { message = "Password change was successful" });
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getUserName")]
        public async Task<IActionResult> GetUserName([FromQuery] string email)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await _userManager.FindByNameAsync(email);
            Console.WriteLine(user);
            if (user == null)
            {
                Log.Error("User name does not exist");
                return Unauthorized();
            }
            Log.Information("User name successfully found");
            return Ok(user);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("userDetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            var userName = User.GetFirstName();
            var user = await _userManager.FindByNameAsync(userName);
            var userDetails = new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
            };
            Console.WriteLine(userDetails);
            Log.Information("Successfully fetched user details");
            return Ok(userDetails);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("editDetails")]
        public async Task<IActionResult> EditUserDetails(editUserDTO userDTO)
        {
            var userName = User.GetFirstName();
            var user = await _userManager.FindByNameAsync(userName);
            user.FirstName = userDTO.firstName;
            user.LastName = userDTO.lastName;
            user.Email = userDTO.email;
            user.PhoneNumber = userDTO.phoneNumber;
            await _userManager.UpdateAsync(user);
             var userDetails = new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
            };
            Log.Information("Edited details successfylly");
            return Ok(userDetails);
        }
        [HttpPost("refresh")]
        public async Task<IActionResult>RefreshPage(TokenResponse tokenResponse)
        {
            var token = tokenResponse.AccessToken;
            Console.WriteLine(token);
            var refreshToken = tokenResponse.RefreshToken;
            if (string.IsNullOrEmpty(refreshToken))
            {
                Log.Error("Refresh token not found");
                return Unauthorized("Refresh token not found");
            }
            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            var email = principal.GetFirstName();
            var user=await _userManager.FindByNameAsync(email);
            if (user == null ||
        user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                Log.Error("Invalid refresh path");
                return Unauthorized();
            }
            var newAccessToken = _tokenService.CreateToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
           user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);
            return Ok(new NewUserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = newAccessToken,
                RefreshToken = newRefreshToken,
            }
            );
        }
        [Authorize]
        [HttpDelete("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var username = User.GetFirstName();
            var user=await _userManager.FindByNameAsync(username);
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            await _userManager.UpdateAsync(user);
            return NoContent();
        }
       
    }
}
