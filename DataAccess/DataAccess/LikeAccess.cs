using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class LikeAccess
    {
        private readonly DataContext _context;

        public LikeAccess(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Like post using its id
        /// </summary>
        /// <param name="id">Id of article</param>
        /// <param name="username">Username of user</param>
        /// <returns>Number of likes</returns>
        public async Task<int> LikePostAsync(int id, string username)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(p => p.Id == id);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            var like = await _context.Likes
                .Include(l => l.User)
                .Include(l => l.Article)
                .FirstOrDefaultAsync(l => l.User == user && l.Article == article);
            if (like is null)
            {
                var newLike = new LikeModel
                {
                    Article = article,
                    User = user
                };
                await _context.Likes.AddAsync(newLike);

            }
            else
            {
                _context.Likes.Remove(like);
            }
            await _context.SaveChangesAsync();
            return await CountLikesAsync(id);
        }
        /// <summary>
        /// get number of likes on post
        /// </summary>
        /// <param name="id">Id of article</param>
        /// <returns>Number of likes</returns>
        public async Task<int> CountLikesAsync(int id)
        {
            var like = await _context.Likes
                .Include(l => l.Article)
                .Where(l => l.Article.Id == id).CountAsync();
            return like;
        }
    }
}
