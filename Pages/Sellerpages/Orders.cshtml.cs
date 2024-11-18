using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerce.Pages.SellerPages
{
    public class OrdersModel : PageModel
    {
        private readonly DBcontext _context;

        public OrdersModel(DBcontext context)
        {
            _context = context;
        }

        public List<order> SellerOrders { get; set; } = new List<order>();

        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve SellerId from session
            var sellerId = HttpContext.Session.GetString("SellerId");

            if (string.IsNullOrEmpty(sellerId))
            {
                return RedirectToPage("SellerLogin");
            }

            // Fetch Seller Orders
            SellerOrders = await _context.Orders
                .Where(o => _context.Products.Any(p => p.Id == o.ProductId && p.SellerId.ToString() == sellerId))
                .ToListAsync();

            // Save product information in session
            var productIds = SellerOrders.Select(o => o.ProductId).ToList();
            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            // Serialize and store products in session
            HttpContext.Session.SetString("SellerProducts", JsonSerializer.Serialize(products));

            return Page();
        }

        public List<product> GetProductsFromSession()
        {
            // Deserialize products from session
            var productsJson = HttpContext.Session.GetString("SellerProducts");
            if (!string.IsNullOrEmpty(productsJson))
            {
                return JsonSerializer.Deserialize<List<product>>(productsJson);
            }

            return new List<product>();
        }
    }
}
