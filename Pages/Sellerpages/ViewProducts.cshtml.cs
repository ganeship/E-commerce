using E_commerce.Data;
using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce.Pages.SellerPages
{
    public class ViewProductsModel : PageModel
    {
        private readonly DBcontext _context;

        public ViewProductsModel(DBcontext context)
        {
            _context = context;
        }
         
        public List<product> SellerProducts { get; set; } = new List<product>();

        public async Task OnGetAsync()
        {
            var sellerId = HttpContext.Session.GetString("SellerId");

            if (!string.IsNullOrEmpty(sellerId))
            {
                var seller = await _context.Sellers
                    .FirstOrDefaultAsync(s => s.Id.ToString() == sellerId);

                if (seller != null)
                {
                    SellerProducts = await _context.Products
                        .Where(p => p.SellerId == seller.Id)
                        .ToListAsync();
                }
            }
            else
            {
                RedirectToPage("SellerLogin");
            }
        }
    }
}
