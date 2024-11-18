using E_commerce.Data;
using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Pages.Sellerpages
{
    public class SellerHomeModel : PageModel
    {
        private readonly DBcontext _context;

        public SellerHomeModel(DBcontext context)
        {
            _context = context;
        }

        // List to hold the seller's products
        public List<ProductSellerInfo> SellerProducts { get; set; } = new List<ProductSellerInfo>();

        public async Task OnGetAsync()
        {
            var sellerEmail = User.Identity.Name;

            // Fetch the logged-in seller's details
            var seller = await _context.Sellers
                .FirstOrDefaultAsync(s => s.Email == sellerEmail);

            if (seller != null)
            {
                // Perform join between Products and Sellers based on SellerId
                var productSellerJoin = from product in _context.Products
                                        join sellerInDb in _context.Sellers on product.SellerId equals sellerInDb.Id
                                        where sellerInDb.Email == sellerEmail // Filter products for the logged-in seller
                                        select new ProductSellerInfo
                                        {
                                            ProductId = product.Id,
                                            ProductName = product.ProductName,
                                            Price = product.Price.ToString(),
                                            Quantity = product.Quantity,
                                            SellerName = sellerInDb.Name,
                                            SellerEmail = sellerInDb.Email
                                        };

                // Assign the results to the SellerProducts list
                SellerProducts = await productSellerJoin.ToListAsync();
            }
        }
    }

    // DTO class to hold product and seller information
    public class ProductSellerInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string SellerName { get; set; }
        public string SellerEmail { get; set; }
    }
}
