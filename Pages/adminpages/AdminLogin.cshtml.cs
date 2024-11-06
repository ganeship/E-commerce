using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages.adminpages
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = "Admin";
        [BindProperty]
        public string Password { get; set; } = "Admin";

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            if (Email == "Admin" && Password == "Admin")
            {
                return RedirectToPage("AdminHome");
            }


            TempData["Admin"] = "Invalid login attempt.";
            return Page();
        }
    }
}
