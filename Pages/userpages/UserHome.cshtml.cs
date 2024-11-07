using Azure.Identity;
using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages.userpages
{
    public class UserHomeModel : PageModel
    {
        private readonly DBcontext dbcontext;

        public List<product> Products { get; set; }

        public UserHomeModel(DBcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

       
        public void OnGet(string category = null, string subcategory = null)
        {
            ViewData["username"] = HttpContext.Session.GetString("UserName");
            Products = dbcontext.Products
                .Where(p => (category == null || p.Category == category) &&
                            (subcategory == null || p.SubCategory == subcategory))
                .ToList();
        }

        public IActionResult OnPostSignout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");
        }
    }
}
