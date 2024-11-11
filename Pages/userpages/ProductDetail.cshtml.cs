/*using E_commerce.Data.Context;
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

                
                return RedirectToPage("/UserPages/cart");
            }

            return Page();
        }
    }
}
*/

using E_commerce.Data.Context;
using E_commerce.Data.Entity;
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
            // Fetch the product details by product ID
            Product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (Product == null)
            {
                return NotFound(); // Handle case if product is not found
            }
            return Page();
        }

        public IActionResult OnPostAddToCart(int productId, int quantity)
        {
            int userId = 1; // You should replace this with the actual user ID if authenticated

            // Check if the product already exists in the cart for the user
            var cartItem = _context.Carts.FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);

            if (cartItem != null)
            {
                // If product is already in cart, update the quantity
                cartItem.Quantity += quantity;
            }
            else
            {
                // If product is not in cart, add a new cart item
                cartItem = new cart
                {
                    ProductId = productId,
                    UserId = userId,
                    Quantity = quantity
                };
                _context.Carts.Add(cartItem);
            }

            // Save changes to the database
            _context.SaveChanges();

            // Redirect the user to the cart page after adding to cart
            return RedirectToPage("/userpages/cart"); // Cart page should be under the 'userpages' folder
        }
    }
}
