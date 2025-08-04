using api.DTO.Account;
using Microsoft.AspNetCore.Mvc;

namespace api.Service.Account
{
    public interface IAccountService
    {
        Task<IActionResult> SignUp(SignUpDto signUpDTO);
        Task<IActionResult> Login(LoginDto loginDTO);
        Task<IActionResult> VerifyEmail(VerifyEmailDTO verifyEmailDTO);
        Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDTO);
        Task<IActionResult> GetUserName(string email);
        Task<IActionResult> GetUserDetails(string email);
        Task<IActionResult> EditUserDetails(string username, editUserDto userDTO);
        Task<IActionResult> RefreshPage(TokenResponseDto tokenResponse);
    }
}
