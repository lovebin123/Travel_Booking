using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Account
{
    public class SignUpDTO
    {
        [Required]
        public string firstName { get; set; }
        public string lastName { get; set; }
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

    }
}
