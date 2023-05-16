using DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<LikeModel> Likes { get; set; }
        public DataContext(DbContextOptions options) : base(options) { }
    }
}
