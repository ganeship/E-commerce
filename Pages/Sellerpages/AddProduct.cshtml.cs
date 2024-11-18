using E_commerce.Data;
using E_commerce.Data.Entity;
using E_commerce.Pages.viewmodelclasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using E_commerce.Data.Context;

namespace E_commerce.Pages.Sellerpages
{
    public class AddProductModel : PageModel
    {
        private readonly DBcontext _context;
        private readonly IWebHostEnvironment _environment;

        public AddProductModel(DBcontext dbContext, IWebHostEnvironment environment)
        {
            _context = dbContext;
            _environment = environment;
        }

        [BindProperty]
        public ModelProducts seller1 { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (seller1 == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid product data.");
                return Page();
            }

            var sellerIdString = HttpContext.Session.GetString("SellerId");
            if (string.IsNullOrEmpty(sellerIdString))
            {
                ModelState.AddModelError(string.Empty, "Please log in as a seller.");
                return RedirectToPage("SellerLogin");
            }

            var sellerId = int.Parse(sellerIdString);

            var seller = _context.Sellers.FirstOrDefault(s => s.Id == sellerId);
            if (seller == null)
            {
                ModelState.AddModelError(string.Empty, "Seller not found.");
                return Page();
            }

            string photoPath1 = await SaveImage(seller1.Image1);
            string photoPath2 = await SaveImage(seller1.Image2);
            string photoPath3 = await SaveImage(seller1.Image3);
            string photoPath4 = await SaveImage(seller1.Image4);

            var addProduct = new product
            {
                ProductId = seller1.ProductId,
                ProductName = seller1.ProductName,
                Description = seller1.Description,
                Category = seller1.Category,
                SubCategory = seller1.SubCategory,
                Price = seller1.Price,
                Quantity = seller1.Quantity,
                ImagePath1 = photoPath1,
                ImagePath2 = photoPath2,
                ImagePath3 = photoPath3,
                ImagePath4 = photoPath4,
                SellerId = seller.Id
            };

            _context.Products.Add(addProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("ViewProducts");
        }

        private async Task<string> SaveImage(IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                return Path.Combine("/images", fileName);
            }
            return null;
        }
    }
}
