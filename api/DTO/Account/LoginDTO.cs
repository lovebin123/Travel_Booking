using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Account
{
    public class LoginDTO
    {
          [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
