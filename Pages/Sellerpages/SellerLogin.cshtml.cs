using E_commerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_commerce.Data.Entity;
using E_commerce.Data.Context;

namespace E_commerce.Pages.Sellerpages
{
    public class SellerLoginModel : PageModel
    {
        private readonly DBcontext _context;
        [BindProperty]
        public SellerLoginViewModel user1 { get; set; }
        public SellerLoginModel(DBcontext context)
        {
            _context = context;
        }

        //[BindProperty]
        //public string Email { get; set; }
        //[BindProperty]
        //public string Password { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(user1.Email) || string.IsNullOrEmpty(user1.Password))
            {
                ModelState.AddModelError(string.Empty, "Email and Password are required.");
                return Page();
            }

            var seller = await _context.Sellers
                .FirstOrDefaultAsync(s => s.Email == user1.Email && s.Password == user1.Password);

            if (seller == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login credentials.");
                return Page();
            }

            HttpContext.Session.SetString("SellerId", seller.Id.ToString());
            

            return RedirectToPage("SellerHome");
        }
    }
}
