using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab11Project.Data;
using Lab11Project.Models;

namespace Lab11Project.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly RP_ShopDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CreateModel(Lab11Project.Data.RP_ShopDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _hostingEnvironment = hostEnvironment;
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if (Article.Image != null)
            {
                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Article.Image.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Article.Image.CopyToAsync(stream);
                }

                Article.ImagePath = Path.Combine("uploads", uniqueFileName);
            }
            else
            {
                Article.ImagePath = Path.Combine("uploads", "default.jpg");
            }

            _context.Articles.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
