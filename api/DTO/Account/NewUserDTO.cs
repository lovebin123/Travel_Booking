using System.ComponentModel.DataAnnotations;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Account
{
    public class NewUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string? Role { get; set; }
        public DateTime  RefreshTokenExpiryTime{ get; set; }
    }
}
