using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Pages.AdminPage
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            
            HttpContext.Session.Clear();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            string adminEmail = "admin@example.com";
            string adminPassword = "admin123";

            if (Email == adminEmail && Password == adminPassword)
            {
                
                HttpContext.Session.SetString("IsAdminLoggedIn", "true");

                
                return RedirectToPage("Dashboard");
            }
            else
            {
                
                ErrorMessage = "Invalid email or password. Please try again.";
                return Page();
            }
        }
    }
}
