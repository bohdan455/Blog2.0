using System.ComponentModel.DataAnnotations;

namespace Web.Model
{
    public class LoginModelDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
