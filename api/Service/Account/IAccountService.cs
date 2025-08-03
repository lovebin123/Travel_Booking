using api.DTO.Account;
using Microsoft.AspNetCore.Mvc;

namespace api.Service.Account
{
    public interface IAccountService
    {
        Task<IActionResult> SignUp(SignUpDTO signUpDTO);
        Task<IActionResult> Login(LoginDTO loginDTO);
        Task<IActionResult> VerifyEmail(VerifyEmailDTO verifyEmailDTO);
        Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
        Task<IActionResult> GetUserName(string email);
        Task<IActionResult> GetUserDetails(string email);
        Task<IActionResult> EditUserDetails(string username, editUserDto userDTO);
        Task<IActionResult> RefreshPage(TokenResponse tokenResponse);
    }
}
