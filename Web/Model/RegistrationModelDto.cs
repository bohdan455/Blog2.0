using System.ComponentModel.DataAnnotations;

namespace Web.Model
{
    public class RegistrationModelDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage ="Must be email")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string RepeatPassword { get; set; } = string.Empty;
    }
}
