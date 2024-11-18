/*using Azure.Identity;
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
*/
using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace E_commerce.Pages.userpages
{
    public class UserHomeModel : PageModel
    {
        private readonly DBcontext dbcontext;

        public UserHomeModel(DBcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<product> Products { get; set; }
        public List<product> filterproducts { get; set; } = new List<product>();
        public Dictionary<string, List<string>> categorySubcategoryGroups { get; set; } = new Dictionary<string, List<string>>();

        public void OnGet(string category, string subcategory)
        {
            Products = dbcontext.Products.ToList();
            categorySubcategoryGroups = Products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.Select(p => p.SubCategory).Distinct().ToList());

            if (!string.IsNullOrEmpty(category))
            {
                filterproducts = dbcontext.Products.Where(p => p.Category == category &&
                                                               (string.IsNullOrEmpty(subcategory) || p.SubCategory == subcategory))
                                                   .ToList();
            }
            else
            {
                filterproducts = Products;
            }
        }

        public IActionResult OnPost(int productId, int quantity, string action)
        {
            int userId = 1; 

            if (action == "add_to_cart")
            {
                
                var existingCartItem = dbcontext.Carts.FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);

                if (existingCartItem != null)
                {
                    
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                   
                    var cartItem = new cart
                    {
                        UserId = userId,
                        ProductId = productId,
                        Quantity = quantity
                    };
                    dbcontext.Carts.Add(cartItem);
                }

                dbcontext.SaveChanges();
                return RedirectToPage("cart");
            }
            else if (action == "buy_now")
            {
                return RedirectToPage("Checkout", new { productId = productId, quantity = quantity });
            }

            return Page();
        }

        public IActionResult OnPostFilter(string category, string subcategory)
        {
            return RedirectToPage(new { category = category, subcategory = subcategory ?? "" });
        }

        public IActionResult OnPostSignout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");

        }
        public IActionResult OnPostOrders()
        {
            return RedirectToPage("UserOrders");
        }

    }
}
