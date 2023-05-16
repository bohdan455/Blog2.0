using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class LikeModel
    {
        [Key]
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public ArticleModel Article { get; set; }
    }
}
