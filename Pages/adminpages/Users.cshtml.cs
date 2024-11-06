using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages.adminpages
{
    public class UsersModel : PageModel
    {
        private readonly DBcontext _context;

        public UsersModel(DBcontext dbContext)
        {
            _context = dbContext;
        }

        public List<user> UserList { get; set; } = new List<user>();  

        public void OnGet()
        {
            UserList = _context.Users.ToList(); 
        }
        public IActionResult OnPostDelete(int id)
        {
            
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
               
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

           
            return RedirectToPage();
        }
    }
}
