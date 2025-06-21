using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTO.Account
{
    public class VerifyEmailDTO
    {
        [Required]
        public string Email { get; set; }
    }
}
