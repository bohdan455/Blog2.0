using DataAccess;
using DataAccess.BlogData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Model;

namespace Web.Pages.Post
{
    [Authorize]
    public class CreateArticleModel : PageModel
    {
        private readonly ArticleAccess _articleAccess;

        public CreateArticleModel(ArticleAccess articleAccess)
        {
            _articleAccess = articleAccess;
        }
        [BindProperty]
        public PostModelDto PostModelDto { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _articleAccess.CreatePostAsync(User.Identity.Name,PostModelDto.Title,PostModelDto.Body,PostModelDto.ImageUrl);
            return RedirectToPage("/index");
        }
    }
}
