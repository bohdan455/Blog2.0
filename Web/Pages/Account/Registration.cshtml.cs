using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Model;

namespace Web.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegistrationModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public RegistrationModelDto RegistrationModelDto{ get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            if(RegistrationModelDto.Password != RegistrationModelDto.RepeatPassword)
            {
                ModelState.AddModelError("Registration", "Passwords must match");
                return Page();
            }
            var user = new IdentityUser
            {
                Email = RegistrationModelDto.Email,
                UserName = RegistrationModelDto.Username
            };
            var result = await _userManager.CreateAsync(user,RegistrationModelDto.Password);
            if(result.Succeeded)
            {
                return RedirectToPage("/account/login");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("Registration", error.Description);
                }
            }
            return Page();
        }
    }
}
