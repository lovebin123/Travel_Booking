using System;

namespace api.DTO.Account
{
    public class NewUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string Role { get; set; }
    }
}
