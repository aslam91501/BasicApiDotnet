using System.ComponentModel.DataAnnotations;

namespace BasicApi.Auth.Models
{
    public class RegistrationRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(32, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}