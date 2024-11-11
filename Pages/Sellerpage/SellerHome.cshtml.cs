using E_commerce.Pages.viewmodelclasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages.Sellerpage
{
    public class SellerHomeModel : PageModel
    {
        public ModelSeller user { get; set; }

    public void OnGet()
        {
        }
    }
}
