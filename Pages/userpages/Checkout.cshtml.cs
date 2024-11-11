using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce.Pages.userpages
{
    public class CheckoutModel : PageModel
    {
        private readonly DBcontext _context;

        public CheckoutModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public List<CartItem> CartItems { get; set; }

        public IActionResult OnGet()
        {
            int userId = 1; // Replace with actual user ID from authentication

            // Fetch the user's cart items
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

        public IActionResult OnPost()
        {
            // Logic to process the checkout (e.g., create an order, reduce stock, etc.)

            // After checkout, clear the cart and redirect to a confirmation page (or order summary)
            return RedirectToPage("/userpages/OrderConfirmation");
        }
    }

    public class CartItem
    {
        public product Product { get; set; }
        public int Quantity { get; set; }
    }
}
