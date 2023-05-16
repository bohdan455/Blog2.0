using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Model;

namespace Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public LoginModelDto LoginModelDto { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            var result = await _signInManager.PasswordSignInAsync(
                LoginModelDto.Username,
                LoginModelDto.Password,
                LoginModelDto.RememberMe,
                true);
            if (result.Succeeded)
            {
                return RedirectToPage("/index");
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "Try later");
                }
                else
                {
                    ModelState.AddModelError("Login", "Your password is incorrect or user doesn't exists");
                }
                return Page();
            }

        }
    }
}
