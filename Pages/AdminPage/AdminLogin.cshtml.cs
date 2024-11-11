using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Pages.Adminpage
{
    public class AdminLoginModel : PageModel
    {
        // Email property
        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        // Password property
        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public void OnGet()
        {
            // Handle GET request if needed (e.g., clearing out any existing session or temp data)
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Add your logic for admin login here.
                // For example, authenticate the admin based on the Email and Password fields.

                // If login successful, redirect to another page or set TempData message
                TempData["Admin"] = "Login successful!";
                return RedirectToPage("/Adminpage/AdminDashboard"); // Example redirect
            }

            // If login fails, stay on the page and show validation errors
            return Page();
        }
    }
}
