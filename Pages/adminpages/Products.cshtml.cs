using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Pages.adminpages
{
    public class ProductsModel : PageModel
    {
        private readonly DBcontext _context;

        public ProductsModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public List<product> ProductsList { get; set; } = new List<product>();

        public void OnGet()
        {
            // Retrieve all products from the database
            ProductsList = _context.Products.AsNoTracking().ToList();
        }

        // Handle the delete action
        public IActionResult OnPostDelete(int productId)
        {
            // Find the product by ID
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                // Remove the product from the database
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            // After deletion, reload the page to reflect the changes
            return RedirectToPage();
        }
    }
}
