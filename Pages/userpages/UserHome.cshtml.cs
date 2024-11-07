using Azure.Identity;
using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Pages.userpages
{
    public class UserHomeModel : PageModel
    {
        private readonly DBcontext dbcontext;

        public List<product> Products { get; set; }

        public List<product> filterproducts { get; set; } = new List<product>();

        public Dictionary<string, List<string>> categorySubcategoryGroups {  get; set; } = new Dictionary<string, List<string>>();


        public UserHomeModel(DBcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [BindProperty]
        public string cate{  get; set; }
        [BindProperty]
        public string subcate { get; set; }
       
        public void OnGet(string category , string subcategory )
        {
            ViewData["username"] = HttpContext.Session.GetString("UserName");
            Products = dbcontext.Products.ToList();
            categorySubcategoryGroups = Products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.Select(p => p.SubCategory).Distinct().ToList());
            if (!string.IsNullOrEmpty(category))
            {
                // Filter products by category and subcategory (example logic)
                filterproducts = dbcontext.Products.Where(p => p.Category == category &&
                                                         (string.IsNullOrEmpty(subcategory) || p.SubCategory == subcategory))
                                             .ToList();
                
            }
            else
            {
                filterproducts= Products;
            }
            
        }

        public IActionResult OnPostFilter(string category , string subcategory )
        {
            if (!string.IsNullOrEmpty(subcategory))
            {
                return RedirectToPage( new { category = category, subcategory = subcategory });
            }
            return RedirectToPage( new { category = category, subcategory="" });
            
        }

        public IActionResult OnPostSignout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");
        }
    }
}
