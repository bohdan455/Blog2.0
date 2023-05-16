using DataAccess.BlogData;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Article
{
    [Authorize]
    public class ArticleContentModel : PageModel
    {
        private readonly ArticleAccess _articleAccess;

        public ArticleContentModel(ArticleAccess articleAccess)
        {
            _articleAccess = articleAccess;
        }
        [BindProperty]
        public ArticleModel ArticleModel { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public int Likes { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            ArticleModel = await _articleAccess.GetArticleByIdAsync(id);
            if (ArticleModel is null) return NotFound();
            Id = id;
            Likes = await _articleAccess.CountLikesAsync(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if(User.Identity.Name is null) return BadRequest();

            await _articleAccess.LikePostAsync(id,User.Identity.Name);
            return RedirectToPage("/article/ArticleContent",new {id});
        }
    }
}
