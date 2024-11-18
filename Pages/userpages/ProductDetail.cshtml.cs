using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using E_commerce.Pages.viewmodelclasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace E_commerce.Pages.userpages
{
    public class ProductDetailModel : PageModel
    {
        private readonly DBcontext _context;

        public ProductDetailModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            
            Product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        [BindProperty]
        public int Quantity { get; set; }

        public IActionResult OnPost(int productId)
        {
            if (ModelState.IsValid)
            {
               
                var cartItem = new ModelCart
                {
                    ProductId = productId,
                    Quantity = Quantity,
                    UserId = 1 
                };

                
                return RedirectToPage("cart");
            }

            return Page();
        }
    }
}

