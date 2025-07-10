using System.ComponentModel.DataAnnotations;

namespace BasicApi.Auth.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(32, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}