using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Auth
{
    public class RegisterUserDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Username { get; set; }
    }
}
