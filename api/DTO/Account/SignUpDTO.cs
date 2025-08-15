using System.ComponentModel.DataAnnotations;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.DTO.Account
{
    public class SignUpDto
    {
        
        public string? firstName { get; set; }

     
        public string? lastName { get; set; }

        public string? email { get; set; }

     
        public string? password { get; set; }
    }
}
