using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_commerce.Pages.AdminPage
{
    public class UserDetailsModel : PageModel
    {
        private readonly DBcontext _context;

        
        public UserDetailsModel(DBcontext context)
        {
            _context = context;
        }

       
        public List<user> Users { get; set; }

       
        public async Task<IActionResult> OnGetAsync()
        {
            
            Users = await _context.Users.ToListAsync();
            return Page();
        }
    }
}
