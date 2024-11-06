using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Pages.adminpages
{
    public class SellerAuthenticationModel : PageModel
    {
        private readonly DBcontext _context;

        public SellerAuthenticationModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public List<seller> SellersList { get; set; } = new List<seller>();

        public void OnGet()
        {
            SellersList = _context.Sellers.Where(p => p.IsVerified == false).AsNoTracking().ToList();
        }

       
        public IActionResult OnPostVerify(int sellerId)
        {
            var seller = _context.Sellers.FirstOrDefault(s => s.Id == sellerId);

            if (seller != null)
            {
                seller.IsVerified = true;
                _context.SaveChanges();
            }

          
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int sellerId)
        {
            var seller = _context.Sellers.FirstOrDefault(s => s.Id == sellerId);

            if (seller != null)
            {
                _context.Sellers.Remove(seller);
                _context.SaveChanges();
            }

            
            return RedirectToPage();
        }
    }
}
