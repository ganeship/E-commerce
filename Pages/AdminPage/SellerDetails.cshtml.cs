using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce.Pages.AdminPage
{
    public class SellerDetailsModel : PageModel
    {
        private readonly DBcontext _context;

        public SellerDetailsModel(DBcontext context)
        {
            _context = context;
        }

        public List<seller> Sellers { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("IsAdminLoggedIn") != "true")
            {
                return RedirectToPage("/AdminPage/AdminLogin");
            }

            Sellers = await _context.Sellers.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostVerifySellerAsync(int id)
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
