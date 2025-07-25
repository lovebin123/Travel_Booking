using System.ComponentModel.DataAnnotations;

namespace api.DTO.Account
{
    public record NewUserDTO
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; init; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; init; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [Display(Name = "Email Address")]
        public string? Email { get; init; }

        [Display(Name = "Access Token")]
        public string? Token { get; init; }

        [Required(ErrorMessage = "Refresh token is required")]
        [Display(Name = "Refresh Token")]
        public string RefreshToken { get; init; }

        [Required(ErrorMessage = "Role is required")]
        [StringLength(20, ErrorMessage = "Role cannot exceed 20 characters")]
        public string Role { get; init; }
    }
}
