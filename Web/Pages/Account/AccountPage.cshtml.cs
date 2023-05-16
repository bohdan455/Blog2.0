using DataAccess.BlogData;
using DataAccess.DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Account
{
    [Authorize]
    public class AccountPageModel : PageModel
    {
        private readonly UserAccess _userAccess;
        private readonly ArticleAccess _articleAccess;

        public AccountPageModel(UserAccess userAccess, ArticleAccess articleAccess)
        {
            _userAccess = userAccess;
            _articleAccess = articleAccess;
        }
        [BindProperty]
        public IdentityUser User { get; set; }
        [BindProperty]
        public IEnumerable<ArticleModel> Articles { get; set; }
        public async Task OnGet(string username)
        {
            User = await _userAccess.GetUserByUsername(username);
            Articles = _articleAccess.GetAllArticlesWrittenByUser(username);

        }
    }
}
