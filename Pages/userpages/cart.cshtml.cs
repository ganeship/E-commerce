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

        public cartModel(DBcontext context)
        {
            _context = context;
        }

        public List<CartItem> CartItems { get; set; }

        public void OnGet()
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            int userId = 1; 
            CartItems = (from cart in _context.Carts
                         join product in _context.Products on cart.ProductId equals product.Id
                         where cart.UserId == userId
                         select new CartItem
                         {
                             Product = product,
                             Quantity = cart.Quantity
                         }).ToList();
        }

      
        public IActionResult OnPostRemoveItem(int productId)
        {
            var cartItem = _context.Carts.FirstOrDefault(c => c.ProductId == productId && c.UserId == 1); // Replace 1 with actual user ID
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

     
        public IActionResult OnPostUpdateQuantity(int productId, int newQuantity)
        {
            var cartItem = _context.Carts.FirstOrDefault(c => c.ProductId == productId && c.UserId == 1); // Replace 1 with actual user ID
            if (cartItem != null && newQuantity > 0)
            {
                cartItem.Quantity = newQuantity;
                _context.SaveChanges();
            }
            return RedirectToPage();
        }

       
        public IActionResult OnPostProceedToCheckout()
        {
            return RedirectToPage("Checkout");
        }

        public class CartItem
        {
            public product Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}
