using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce.Pages.AdminPage
{
    public class VerifySellersModel : PageModel
    {
        private readonly DBcontext _context;

        public VerifySellersModel(DBcontext context)
        {
            _context = context;
        }

        public List<seller> UnverifiedSellers { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("IsAdminLoggedIn") != "true")
            {
                return RedirectToPage("/AdminPage/AdminLogin");
            }

           
            UnverifiedSellers = await _context.Sellers
                .Where(s => !s.IsVerified)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostVerifyAsync(int id)
        {
            
            var seller = await _context.Sellers.FindAsync(id);
            if (seller != null)
            {
                seller.IsVerified = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
