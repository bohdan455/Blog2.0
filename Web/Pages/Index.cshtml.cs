using DataAccess.BlogData;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ArticleAccess _articleAccess;

        public IndexModel(ArticleAccess articleAccess)
        {
            _articleAccess = articleAccess;
        }

        [BindProperty]
        public IEnumerable<ArticleModel> ArticleModels { get; set; }
        public void OnGet()
        {
            ArticleModels = _articleAccess.GetAllArticles();
        }
    }
}