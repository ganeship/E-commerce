using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Pages.userpages
{
    public class CheckoutModel : PageModel
    {
        private readonly DBcontext _context;

        public CheckoutModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public CartItem cart { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoneNumber { get; set; }

        public async Task OnGetAsync()
        {
            await PopulateCartItemsAsync();
        }
        public async Task<IActionResult> OnPostPlaceOrderAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToPage("UserLogin");
            }

            await PopulateCartItemsAsync();

            List<string> errors = new List<string>();

            foreach (var item in CartItems)
            {
                var currentQuantity = HttpContext.Session.GetInt32($"ProductQuantity_{item.Product.Id}") ?? 0;

                if (item.Quantity > currentQuantity)
                {
                    errors.Add($"Ordered quantity for {item.Product.ProductName} exceeds available stock.");
                }
            }

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError("Quantity", error);
                }
                return Page();
            }

            foreach (var item in CartItems)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.Product.Id);
                var currentQuantity = HttpContext.Session.GetInt32($"ProductQuantity_{item.Product.Id}") ?? 0;

                if (product != null && currentQuantity >= item.Quantity)
                {
                    int newQuantity = currentQuantity - item.Quantity;
                    HttpContext.Session.SetInt32($"ProductQuantity_{item.Product.Id}", newQuantity);
                    product.Quantity = newQuantity;

                    var order = new order
                    {
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        UserId = userId.Value,
                        UserAddress = UserAddress,
                        OrderedDate = DateTime.Now,
                        Quantity = item.Quantity
                    };

                    _context.Orders.Add(order);
                }
            }

            await _context.SaveChangesAsync();

            var latestOrder = await _context.Orders.OrderByDescending(o => o.Id).FirstOrDefaultAsync();
            if (latestOrder != null)
            {
                HttpContext.Session.SetString("OrderId", latestOrder.Id.ToString());
            }

            return RedirectToPage("OrderConfirmation");
        }

        private async Task PopulateCartItemsAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user != null)
                {
                    UserName = user.Name;
                    UserPhoneNumber = user.PhoneNumber;
                    UserAddress = $"{user.Address1} {(user.Address2 != null ? ", " + user.Address2 : "")}";
                }

                CartItems = await (from cart in _context.Carts
                                   join product in _context.Products on cart.ProductId equals product.Id
                                   where cart.UserId == userId
                                   select new CartItem
                                   {
                                       Product = product,
                                       Quantity = cart.Quantity
                                   }).ToListAsync();

                foreach (var item in CartItems)
                {
                    HttpContext.Session.SetInt32($"ProductQuantity_{item.Product.Id}", item.Product.Quantity);
                }
            }
        }

        public class CartItem
        {
            public product Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}
