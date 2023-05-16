using System.ComponentModel.DataAnnotations;

namespace Web.Model
{
    public class PostModelDto
    {
        [Required]
        [StringLength(400)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(4000)]
        public string Body { get; set; } = string.Empty;
        [MaxLength(400)]
        public string? ImageUrl { get; set; }
    }
}
