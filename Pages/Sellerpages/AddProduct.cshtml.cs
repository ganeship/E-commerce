
using E_commerce.Data.Context;
using E_commerce.Data.Entity;
using E_commerce.Pages.viewmodelclasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace E_commerce.Pages.Sellerpages
{
  public class AddProductModel : PageModel
    {
        
            private readonly DBcontext _context;

            public AddProductModel(DBcontext dbContext)
            {
                _context = dbContext;
            }

        [BindProperty]
        public ModelProducts seller1 {  get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (seller1== null)
            {
                ModelState.AddModelError(string.Empty, "Invalid user data.");
                return Page();
            }
            string photoPath1 = null;
            if (seller1.Image1 != null )
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var fileName = Path.GetFileName(seller1.Image1.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    seller1.Image1.CopyTo(stream);
                }

                photoPath1 = filePath;
            }


            string photoPath2 = null;
            if (seller1.Image2 != null )
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var fileName = Path.GetFileName(seller1.Image2.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    seller1.Image2.CopyTo(stream);
                }

                photoPath2 = filePath;
            }

            string photoPath3 = null;
            if (seller1.Image3 != null )
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var fileName = Path.GetFileName(seller1.Image3.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    seller1.Image3.CopyTo(stream);
                }

                photoPath3 = filePath;
            }
            string photoPath4 = null;
            if (seller1.Image4 != null)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var fileName = Path.GetFileName(seller1.Image4.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    seller1.Image4.CopyTo(stream);
                }

                photoPath4 =filePath;
            }


            var addpr = new product
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
                ImagePath4 = photoPath4
            };

            _context.Products.Add(addpr);
            _context.SaveChanges();

            return RedirectToPage("SellerLogin");
        }
    }
    }




