using System;
using api.DTO.Account;
using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

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
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_ID");
            var client = new SendGridClient(apiKey);
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
                    var role = user.Email == "admin@gmail.com" ? "Admin" : "User";
                    var roleResult = await _userManager.AddToRoleAsync(user, role);
                    Console.WriteLine(role);
                    Console.WriteLine(roleResult);
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDTO
                            {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user),
                                Role = role,
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception e)
            {
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
                return Unauthorized("Invalid username");
            var result = await _signinManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: true, lockoutOnFailure: false);
            if (!result.Succeeded)
                return Unauthorized("Username does not exist");
            var role = user.Email == "admin@gmail.com" ? "Admin" : "User";
            var roleResult = await _userManager.AddToRoleAsync(user, role);
            return Ok(new NewUserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Role = role

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
                return Ok(new { username = verifyEmailDTO.Email });
            else
                return StatusCode((int)response.StatusCode, "Failed to send email");
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByNameAsync(forgotPasswordDTO.Email);
            if (user == null)
                return Unauthorized("User does not exist");
            var result = await _userManager.RemovePasswordAsync(user);
            if (!result.Succeeded)
                return Unauthorized("Failed to change password");
            result = await _userManager.AddPasswordAsync(user, forgotPasswordDTO.Password);
            if (!result.Succeeded)
                return Unauthorized("Password change failed");
            return Ok(new { message = "Password change was successful" });
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getUserName")]
        public async Task<IActionResult> GetUserName([FromQuery] string email)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
                return Unauthorized();
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
            return Ok(userDetails);
        }
       
    }
}
