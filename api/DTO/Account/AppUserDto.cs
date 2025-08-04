using System.ComponentModel.DataAnnotations;
namespace api.DTO.Account
{
    public record AppUserDto
    {
        [Required]
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

    }
}
