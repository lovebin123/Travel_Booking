using System.ComponentModel.DataAnnotations;

namespace api.DTO.Account
{
    public class NewUserDTO
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Display(Name = "Access Token")]
        public string? Token { get; set; }

        [Required(ErrorMessage = "Refresh token is required")]
        [Display(Name = "Refresh Token")]
        public string RefreshToken { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [StringLength(20, ErrorMessage = "Role cannot exceed 20 characters")]
        public string Role { get; set; }
        public DateTime  RefreshTokenExpiryTime{ get; set; }
    }
}
