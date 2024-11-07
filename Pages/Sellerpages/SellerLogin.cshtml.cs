using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages.Sellerpages
{
    public class SellerLoginModel : PageModel
    {
        private readonly DBcontext _context;

       
        [BindProperty]
        public SellerLoginViewModel  user1{ get; set; } = new SellerLoginViewModel();

        public SellerLoginModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            var existingUser = _context.Sellers
                .FirstOrDefault(u => u.Email == user1.Email && u.Password == user1.Password);

            if (existingUser == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            
            return RedirectToPage("AddProduct");
        }
    }
}
