using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using E_commerce.Pages.viewmodelclasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages.Sellerpages
{
    public class SellerSignUpModel : PageModel
    {
        private readonly DBcontext _context;

        public SellerSignUpModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        [BindProperty]
        public ModelSeller user { get; set; }  

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid user data.");
                return Page();
            }

            var SellerSignin = new seller
            
            {
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Address = user.Address,
                Password = user.Password,
                PinCode = user.PinCode,
                ShopName=user.ShopName,
                IsVerified = false
            };

            _context.Sellers.Add(SellerSignin);
            _context.SaveChanges();

            return RedirectToPage("SellerLogin");
        }
    }
}
