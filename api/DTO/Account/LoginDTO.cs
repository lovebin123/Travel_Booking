using api.Validators;
using System.ComponentModel.DataAnnotations;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Account
{
    public record LoginDto(
    [ SmartRequired(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address format")]
    [ StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    [Display(Name = "Email Address")]
    string? Email,

    [   SmartRequired(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
    [   DataType(DataType.Password)]
    [   Display(Name = "Password")]
    string? Password
);
}
