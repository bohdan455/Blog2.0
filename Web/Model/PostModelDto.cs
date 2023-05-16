using System.ComponentModel.DataAnnotations;

namespace Web.Model
{
    public class PostModelDto
    {
        [Required]
        [MaxLength(400)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(4000)]
        public string Body { get; set; } = string.Empty;
    }
}
