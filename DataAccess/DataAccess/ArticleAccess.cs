using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BlogData
{
    public class ArticleAccess
    {
        private readonly DataContext _context;

        public ArticleAccess(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Create post using username of author
        /// </summary>
        /// <param name="username">Username of author</param>
        /// <param name="title">Title of article</param>
        /// <param name="body">Context of article</param>
        /// <param name="imageUrl">Url of image,</param>
        public async Task CreatePostAsync(string username, string title,string body,string imageUrl = null)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            var article = new ArticleModel
            {
                Author = user,
                Title = title,
                Body = body,
                ImageUrl = imageUrl,
            };
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<ArticleModel> GetAllArticles()
        {
            return _context.Articles.Include(a => a.Author);
        }
        public IEnumerable<ArticleModel> GetAllArticlesWrittenByUser(string username)
        {
            return _context.Articles.Include(a => a.Author).Where( a => a.Author.UserName == username);
        }
        /// <summary>
        /// Get article using its id
        /// </summary>
        /// <param name="id">id of article</param>
        /// <returns></returns>
        public async Task<ArticleModel> GetArticleByIdAsync(int id)
        {
            return await _context.Articles.Include(a => a.Author).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
