using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ArticleModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(400)]
        public string Title { get; set; }
        [Required]
        [MaxLength(4000)]
        public string Body { get; set; }
        [MaxLength(400)]
        public string ImageUrl { get; set; }
        [Required]
        public IdentityUser Author { get; set; }
    }
}
