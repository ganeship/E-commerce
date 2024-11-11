using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages.userpages
{
    public class cartModel : PageModel
    {
        private readonly DBcontext _context;

        public cartModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public List<CartItem> CartItems { get; set; }

        public IActionResult OnGet()
        {
          
            int userId = 1;

            CartItems = (from cart in _context.Carts
                         join product in _context.Products on cart.ProductId equals product.ProductId
                         where cart.UserId == userId
                         select new CartItem
                         {
                             Product = product,
                             Quantity = cart.Quantity
                         }).ToList();

            return Page();
        }
    }

    public class CartItem
    {
        public product Product { get; set; }
        public int Quantity { get; set; }
    }
}
*/


using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce.Pages.userpages
{
    public class cartModel : PageModel
    {
        private readonly DBcontext _context;

        public cartModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        // CartItems will be populated and passed to the view.
        public List<CartItem> CartItems { get; set; }

        public IActionResult OnGet()
        {
            int userId = 1; // Replace this with the actual authenticated user's ID if applicable.

            // Fetch cart items for the user, including product details and quantities.
            CartItems = (from cart in _context.Carts
                         join product in _context.Products on cart.ProductId equals product.ProductId
                         where cart.UserId == userId
                         select new CartItem
                         {
                             Product = product,
                             Quantity = cart.Quantity
                         }).ToList();

            // If there are no cart items, you may want to redirect to a page or show a message.
            if (CartItems == null || !CartItems.Any())
            {
                // Optionally redirect to an empty cart or some other page
                // return RedirectToPage("/EmptyCart"); 
                // or just return the page with a message that the cart is empty
            }

            return Page();
        }

        // CartItem class holds product details and quantity.
        public class CartItem
        {
            public product Product { get; set; }
            public int Quantity { get; set; }

        public void OnGet()
        {
        }
    }
}

}