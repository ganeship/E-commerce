using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce.Pages.AdminPage
{
    public class OrderDetailsModel : PageModel
    {
        private readonly DBcontext _context;

        public OrderDetailsModel(DBcontext context)
        {
            _context = context;
        }

     
        public List<order> Orders { get; set; }

       
        public async Task<IActionResult> OnGetAsync()
        {
           
            Orders = await _context.Orders
                 
                .ToListAsync();
            return Page();
        }
    }
}
