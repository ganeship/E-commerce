using E_commerce.Data;
using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce.Pages.SellerPages
{
    public class ManageProductsModel : PageModel
    {
        private readonly DBcontext _context;

        public ManageProductsModel(DBcontext context)
        {
            _context = context;
        }

        public List<product> SellerProducts { get; set; } = new List<product>();

        public async Task<IActionResult> OnGetAsync()
        {
            var sellerId = HttpContext.Session.GetString("SellerId");

            if (string.IsNullOrEmpty(sellerId))
            {
                return RedirectToPage("SellerLogin");
            }

            // Fetch products for the logged-in seller
            SellerProducts = await _context.Products
                .Where(p => p.SellerId.ToString() == sellerId)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostEnableAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null && product.SellerId.ToString() == HttpContext.Session.GetString("SellerId"))
            {
                product.IsActive = 1;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDisableAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null && product.SellerId.ToString() == HttpContext.Session.GetString("SellerId"))
            {
                product.IsActive = 0;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public IActionResult OnPostEdit(int id)
        {
            // Redirect to an edit page or implement inline editing as needed
            return RedirectToPage("EditProduct", new { id });
        }
    }
}
