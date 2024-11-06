using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Pages.adminpages
{
    public class SellersModel : PageModel
    {

        private readonly DBcontext _context;


        public SellersModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public List<seller> SellersList { get; set; } = new List<seller>();
        public void OnGet()
        {
            SellersList = _context.Sellers.Where(p => p.IsVerified == true).AsNoTracking().ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            
            var seller = _context.Sellers.FirstOrDefault(s => s.Id == id);
            if (seller != null)
            {
               
                _context.Sellers.Remove(seller);
                _context.SaveChanges();
            }

           
            return RedirectToPage();
        }
    }
}
