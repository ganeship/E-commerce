
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
        private readonly IWebHostEnvironment _environment;

        public AddProductModel(DBcontext dbContext, IWebHostEnvironment env)
        {
            _context = dbContext;
            _environment = env;
        }

        [BindProperty]
        public ModelProducts SellerProduct { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        
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

            // Directory to store images
            var uploadsFolderPath = Path.Combine(_environment.WebRootPath, "images");

            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            // Save Images and get their paths
            var imagePaths = new string[4];
            if (SellerProduct.Image1 != null)
            {
                imagePaths[0] = await SaveImageAsync(SellerProduct.Image1, uploadsFolderPath);
            }
            if (SellerProduct.Image2 != null)
            {
                imagePaths[1] = await SaveImageAsync(SellerProduct.Image2, uploadsFolderPath);
            }
            if (SellerProduct.Image3 != null)
            {
                imagePaths[2] = await SaveImageAsync(SellerProduct.Image3, uploadsFolderPath);
            }
            if (SellerProduct.Image4 != null)
            {
                imagePaths[3] = await SaveImageAsync(SellerProduct.Image4, uploadsFolderPath);
            }

            // Save Product to the database
            var newProduct = new product
            {
                ProductId = SellerProduct.ProductId,
                ProductName = SellerProduct.ProductName,
                Description = SellerProduct.Description,
                Category = SellerProduct.Category,
                SubCategory = SellerProduct.SubCategory,
                Price = SellerProduct.Price,
                Quantity = SellerProduct.Quantity,
                ImagePath1 = imagePaths[0],
                ImagePath2 = imagePaths[1],
                ImagePath3 = imagePaths[2],
                ImagePath4 = imagePaths[3]
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("SellerLogin");
        }

        // Helper Method to Save Image
        private async Task<string> SaveImageAsync(IFormFile imageFile, string uploadFolder)
        {
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            // Return relative path to store in the database
            return "/images/" + uniqueFileName;
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




