using api.DTO.Account;
using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Service;
using api.Service.Account;
using Asp.Versioning;
using AutoWrapper.Filters;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;
using System;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("signup")]
        [AutoWrapIgnore(ShouldLogRequestData =false)]

        public Task<IActionResult> SignUp([FromBody] SignUpDto dto) => _accountService.SignUp(dto);

        [HttpPost("login")]
        [AutoWrapIgnore(ShouldLogRequestData = false)]
        public Task<IActionResult> Login([FromBody] LoginDto dto) => _accountService.Login(dto);

        [HttpPost("verifyEmail")]
        public Task<IActionResult> VerifyEmail([FromBody] VerifyEmailDTO dto) => _accountService.VerifyEmail(dto);

        [HttpPost("forgotPassword")]
        public Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto) => _accountService.ForgotPassword(dto);

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getUserName")]
        public Task<IActionResult> GetUserName([FromQuery] string email) => _accountService.GetUserName(email);

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("userDetails")]
        public Task<IActionResult> GetUserDetails() => _accountService.GetUserDetails(User.GetFirstName());

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("editDetails")]
        public Task<IActionResult> EditUserDetails([FromBody] editUserDto dto) => _accountService.EditUserDetails(User.GetFirstName(), dto);

        [HttpPost("refresh")]
        public Task<IActionResult> RefreshPage([FromBody] TokenResponseDto tokenResponse) => _accountService.RefreshPage(tokenResponse);
    }
}
